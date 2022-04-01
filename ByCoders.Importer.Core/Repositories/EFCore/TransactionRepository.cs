using ByCoders.Importer.Core.BusinessEntities;
using ByCoders.Importer.Core.Exceptions;
using ByCoders.Importer.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ByCoders.Importer.Core.Repositories.EFCore
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext dbContext;

        public TransactionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task InsertAsync(Transactions transactions)
        {
            await dbContext.Set<Transactions>().AddAsync(transactions);
        }

        public IQueryable<Transactions> List(IQueryParameters parameters)
        {
            if (parameters == null)
            {
                throw new MissingQueryParametersException();
            }

            var list = dbContext.Set<Transactions>().AsQueryable();

            if (parameters?.Filters?.Any() ?? false)
            {
                var filters = new Dictionary<string, object>(parameters.Filters, StringComparer.InvariantCultureIgnoreCase);

                if (filters.ContainsKey(nameof(Transactions.TransactionType)))
                {
                    list = list.Where(x => x.TransactionTypeID == Convert.ToInt32(filters[nameof(Transactions.TransactionType)]));
                }

                if (filters.ContainsKey(nameof(Transactions.CPF)))
                {
                    list = list.Where(x => EF.Functions.Like(x.CPF, $"%{filters[nameof(Transactions.CPF)]}%"));
                }

                if (filters.ContainsKey(nameof(Transactions.ShopName)))
                {
                    list = list.Where(x => EF.Functions.Like(x.CPF, $"%{filters[nameof(Transactions.ShopName)]}%"));
                }

                if (filters.ContainsKey(nameof(Transactions.ShopOwner)))
                {
                    list = list.Where(x => EF.Functions.Like(x.CPF, $"%{filters[nameof(Transactions.ShopOwner)]}%"));
                }
            }

            if (parameters?.Sort?.Any() ?? false)
            {
                var sort = new Dictionary<string, string>(parameters.Sort, StringComparer.InvariantCultureIgnoreCase);

                if (sort.ContainsKey(nameof(Transactions.TransactionType)))
                {
                    list = sort[nameof(Transactions.TransactionType)] == "asc" ? list.OrderBy(x => x.TransactionType.Description) : list.OrderByDescending(x => x.TransactionType.Description);
                }

                if (sort.ContainsKey(nameof(Transactions.Date)))
                {
                    list = sort[nameof(Transactions.Date)] == "asc" ? list.OrderBy(x => x.Date) : list.OrderByDescending(x => x.Date);
                }

                if (sort.ContainsKey(nameof(Transactions.ShopName)))
                {
                    list = sort[nameof(Transactions.ShopName)] == "asc" ? list.OrderBy(x => x.ShopName) : list.OrderByDescending(x => x.ShopName);
                }

                if (sort.ContainsKey(nameof(Transactions.ShopOwner)))
                {
                    list = sort[nameof(Transactions.ShopOwner)] == "asc" ? list.OrderBy(x => x.ShopOwner) : list.OrderByDescending(x => x.ShopOwner);
                }
            }

            return list
                .Skip(parameters.StartRow)
                .Take(parameters.EndRow);
        }
    }
}