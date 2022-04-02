using ByCoders.Importer.WebApi.Controllers;
using ByCoders.Importer.WebApi.Models;
using ByCoders.Importer.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using Xunit;

namespace ByCoders.Importer.Test.WebApiControllers
{
    public class CatalogsControllerTest
    {
        public Mock<ICatalogService> catalogServiceMock = new Mock<ICatalogService>();

        [Fact]
        public void GetTransactionTypes()
        {
             var transactionTypes = (new[] {
                new TransactionTypesCatalogModel { ID = 1, Description = "Type 1"},
                new TransactionTypesCatalogModel { ID = 2, Description = "Type 2"},
                new TransactionTypesCatalogModel { ID = 3, Description = "Type 3"},
            }).AsQueryable();

            catalogServiceMock.Setup(p => p.ListTransactionTypes()).Returns(transactionTypes);

            CatalogsController controller = new(catalogServiceMock.Object);
            var result = controller.TransactionTypes() as ObjectResult;

            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);
            Assert.IsType(transactionTypes.GetType(), result?.Value);
            Assert.Equal(StatusCodes.Status200OK, result?.StatusCode);

            Assert.Equal(transactionTypes.Count(), (result?.Value as IQueryable<TransactionTypesCatalogModel>)?.Count() ?? 0);
        }
    }
}