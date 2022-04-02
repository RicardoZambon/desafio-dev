using AutoMapper;
using AutoMapper.QueryableExtensions;
using ByCoders.Importer.Core;
using ByCoders.Importer.Core.BusinessEntities;
using ByCoders.Importer.Core.Repositories;
using ByCoders.Importer.WebApi.Exceptions;
using ByCoders.Importer.WebApi.Models;

namespace ByCoders.Importer.WebApi.Services.Handlers
{
    public class TransactionsServiceDefault : ITransactionService
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ITransactionTypeRepository transactionTypeRepository;
        private readonly ITransactionRepository transactionRepository;

        public TransactionsServiceDefault(AppDbContext dbContext, IMapper mapper, ITransactionTypeRepository transactionTypeRepository, ITransactionRepository transactionRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.transactionTypeRepository = transactionTypeRepository;
            this.transactionRepository = transactionRepository;
        }

        public async Task ImportTransactionsFromFile(IFormFile file)
        {
            using var fileStream = file.OpenReadStream();
            using var stream = new StreamReader(fileStream);

            var transactionTypesIds = transactionTypeRepository.List().ToArray();

            using var dbTransaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                string line;
                while ((line = stream.ReadLine() ?? string.Empty) != string.Empty)
                {
                    var transactionTypeId = Convert.ToInt32(line[..1]);

                    if (transactionTypesIds.FirstOrDefault(x => x.ID.Equals(transactionTypeId)) is TransactionTypes transactionType)
                    {
                        var year = Convert.ToInt32(line.Substring(1, 4));
                        var month = Convert.ToInt32(line.Substring(5, 2));
                        var day = Convert.ToInt32(line.Substring(7, 2));
                        var hour = Convert.ToInt32(line.Substring(42, 2));
                        var minute = Convert.ToInt32(line.Substring(44, 2));
                        var second = Convert.ToInt32(line.Substring(46, 2));

                        var value = Convert.ToDecimal(line.Substring(9, 10)) / 100;

                        if (transactionType.Kind == BusinessEnums.TransactionTypeKinds.Withdraw)
                        {
                            value *= -1;
                        }

                        var taxId = line.Substring(19, 11);
                        var cardNumber = line.Substring(30, 12);
                        var shopOwner = line.Substring(48, 14).Trim();
                        var shopName = line.Substring(62, 18).Trim();

                        var recordTransaction = new Transactions
                        {
                            TransactionTypeID = transactionTypeId,
                            Date = new DateTime(year, month, day, hour, minute, second),
                            Value = value,
                            CPF = taxId,
                            CardNumber = cardNumber,
                            ShopOwner = shopOwner,
                            ShopName = shopName
                        };

                        await transactionRepository.InsertAsync(recordTransaction);
                    }
                    else
                    {
                        throw new InvalidTransactionTypeException();
                    }
                }

                await dbContext.SaveChangesAsync();
                await dbTransaction.CommitAsync();
            }
            catch
            {
                await dbTransaction.RollbackAsync();
            }
        }

        public IQueryable<TransactionsModel> List(QueryParametersModel parameters)
        {
            return transactionRepository.List(parameters).ProjectTo<TransactionsModel>(mapper.ConfigurationProvider);
        }

        public TransactionsSummaryModel Summary(SummaryParametersModel parameters)
        {
            var transactions = transactionRepository.List(parameters);

            return new TransactionsSummaryModel
            {
                TotalItems = transactions.Count(),
                TotalValue = transactions.Sum(x => x.Value)
            };
        }
    }
}