using AutoMapper;
using ByCoders.Importer.Core;
using ByCoders.Importer.Core.BusinessEntities;
using ByCoders.Importer.Core.Repositories;
using ByCoders.Importer.WebApi.Models;
using ByCoders.Importer.WebApi.Services.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using System.IO;
using System.Linq;
using System.Threading;
using Xunit;

namespace ByCoders.Importer.Test.WebApiServices
{
    public class TransactionsServiceTest
    {
        private readonly IMapper mapper;

        private readonly Mock<IDbContextTransaction> dbTransactionMock;
        private readonly Mock<AppDbContext> contextMock;

        public Mock<ITransactionRepository> transactionRepositoryMock = new Mock<ITransactionRepository>();
        public Mock<ITransactionTypeRepository> transactionTypeRepositoryMock = new Mock<ITransactionTypeRepository>();

        public TransactionsServiceTest()
        {
            dbTransactionMock = new Mock<IDbContextTransaction>();

            contextMock = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            contextMock.Setup(p => p.Database).Returns(new Mock<DatabaseFacade>(contextMock.Object).Object);
            contextMock.Setup(p => p.Database.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbTransactionMock.Object);

            var configuration = new MapperConfiguration(c => c.AddMaps(typeof(WebApi.Services.ICatalogService).Assembly));
            mapper = new Mapper(configuration);
        }

        [Fact]
        public async void ImportTransactionsFromFile()
        {
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            writer.Write("3201903010000014200096206760174753****3153153453JOÃO MACEDO   BAR DO JOÃO       ");
            writer.Flush();
            stream.Position = 0;

            IFormFile file = new FormFile(stream, 0, stream.Length, "CNAB", "CNAB.txt");


            var transactionTypes = (new[] {
                new TransactionTypes() { ID = 3 }
            }).AsQueryable();


            transactionTypeRepositoryMock.Setup(p => p.List()).Returns(transactionTypes);

            TransactionsServiceDefault service = new(contextMock.Object, mapper, transactionTypeRepositoryMock.Object, transactionRepositoryMock.Object);
            await service.ImportTransactionsFromFile(file);

            transactionRepositoryMock.Verify(m => m.InsertAsync(It.IsAny<Transactions>()), Times.Once);

            contextMock.Verify(m => m.SaveChangesAsync(CancellationToken.None), Times.Once);

            dbTransactionMock.Verify(m => m.CommitAsync(CancellationToken.None), Times.Once);
        }

        [Fact]
        public void List()
        {
            var transactions = (new[] {
                new Transactions() { TransactionType = new TransactionTypes() },
                new Transactions() { TransactionType = new TransactionTypes() }
            }).AsQueryable();

            QueryParametersModel parameters = new();

            transactionRepositoryMock.Setup(p => p.List(parameters)).Returns(transactions);

            TransactionsServiceDefault service = new(contextMock.Object, mapper, transactionTypeRepositoryMock.Object, transactionRepositoryMock.Object);
            var result = service.List(parameters);

            Assert.NotNull(result);
            Assert.Equal(transactions.Count(), result.Count());
        }

        [Fact]
        public void Summary()
        {
            var transactions = (new[] {
                new Transactions() { Value = 70 },
                new Transactions() { Value = 30 }
            }).AsQueryable();

            SummaryParametersModel parameters = new();

            transactionRepositoryMock.Setup(p => p.List(parameters)).Returns(transactions);

            TransactionsServiceDefault service = new(contextMock.Object, mapper, transactionTypeRepositoryMock.Object, transactionRepositoryMock.Object);
            var result = service.Summary(parameters);

            Assert.NotNull(result);
            Assert.Equal(2, result.TotalItems);
            Assert.Equal(100, result.TotalValue);
        }
    }
}