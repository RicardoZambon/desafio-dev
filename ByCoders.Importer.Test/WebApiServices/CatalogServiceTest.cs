using AutoMapper;
using ByCoders.Importer.Core.BusinessEntities;
using ByCoders.Importer.Core.Repositories;
using ByCoders.Importer.WebApi.Services.Handlers;
using Moq;
using System.Linq;
using Xunit;

namespace ByCoders.Importer.Test.WebApiServices
{
    public class CatalogServiceTest
    {
        private readonly IMapper mapper;

        public Mock<ITransactionTypeRepository> transactionRepositoryMock = new Mock<ITransactionTypeRepository>();

        public CatalogServiceTest()
        {
            var configuration = new MapperConfiguration(c => c.AddMaps(typeof(WebApi.Services.ICatalogService).Assembly));
            mapper = new Mapper(configuration);
        }

        [Fact]
        public void GetTransactionTypes()
        {
            var transactionTypes = (new[] {
                new TransactionTypes(),
                new TransactionTypes()
            }).AsQueryable();

            transactionRepositoryMock.Setup(p => p.List()).Returns(transactionTypes);

            CatalogServicesDefault service = new(mapper, transactionRepositoryMock.Object);
            var result = service.ListTransactionTypes();

            Assert.NotNull(result);
            Assert.Equal(transactionTypes.Count(), result.Count());
        }
    }
}