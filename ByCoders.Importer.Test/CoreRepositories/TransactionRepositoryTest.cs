using ByCoders.Importer.Core;
using ByCoders.Importer.Core.BusinessEntities;
using ByCoders.Importer.Core.Repositories.EFCore;
using ByCoders.Importer.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using System.Threading;
using Xunit;

namespace ByCoders.Importer.Test.CoreRepositories
{
    public class TransactionRepositoryTest
    {
        private readonly Mock<AppDbContext> contextMock;

        public TransactionRepositoryTest()
        {
            contextMock = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
        }

        [Fact]
        public async void InsertAsync()
        {
            contextMock.Setup(p => p.Set<Transactions>()).Returns(DbSetMock.CreateDbSetMock<Transactions>().Object);

            TransactionRepository repository = new(contextMock.Object);
            await repository.InsertAsync(It.IsAny<Transactions>());

            contextMock.Verify(m => m.Set<Transactions>().AddAsync(It.IsAny<Transactions>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public void List()
        {
            var transactions = (new[] {
                new Transactions(),
                new Transactions(),
            }).AsQueryable();

            contextMock.Setup(p => p.Set<Transactions>()).Returns(DbSetMock.CreateDbSetMock(transactions).Object);

            TransactionRepository repository = new(contextMock.Object);
            var result = repository.List(new QueryParametersModel() { StartRow = 0, EndRow = 100 });

            Assert.NotNull(result);
            Assert.Equal(transactions.Count(), result.Count());
        }
    }
}