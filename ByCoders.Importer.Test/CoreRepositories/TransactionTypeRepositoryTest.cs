using ByCoders.Importer.Core;
using ByCoders.Importer.Core.BusinessEntities;
using ByCoders.Importer.Core.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using Xunit;

namespace ByCoders.Importer.Test.CoreRepositories
{
    public class TransactionTypeRepositoryTest
    {
        private readonly Mock<AppDbContext> contextMock;

        public TransactionTypeRepositoryTest()
        {
            contextMock = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
        }

        [Fact]
        public void List()
        {
            var transactionTypes = (new[] {
                new TransactionTypes(),
                new TransactionTypes(),
            }).AsQueryable();

            contextMock.Setup(p => p.Set<TransactionTypes>()).Returns(DbSetMock.CreateDbSetMock(transactionTypes).Object);

            TransactionTypeRepository service = new(contextMock.Object);
            var result = service.List();

            Assert.NotNull(result);
            Assert.Equal(transactionTypes.Count(), result.Count());
        }
    }
}