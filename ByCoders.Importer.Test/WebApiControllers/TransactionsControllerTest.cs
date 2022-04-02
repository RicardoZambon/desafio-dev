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
    public class TransactionsControllerTest
    {
        public Mock<ITransactionService> transactionServiceMock = new Mock<ITransactionService>();

        [Fact]
        public void List()
        {
             var transactions = (new[] {
                new TransactionsModel(),
                new TransactionsModel(),
            }).AsQueryable();

            QueryParametersModel parameters = new();

            transactionServiceMock.Setup(p => p.List(parameters)).Returns(transactions);

            TransactionsController controller = new(transactionServiceMock.Object);
            var result = controller.List(parameters) as ObjectResult;

            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);
            Assert.IsType(transactions.GetType(), result?.Value);
            Assert.Equal(StatusCodes.Status200OK, result?.StatusCode);

            Assert.Equal(transactions.Count(), (result?.Value as IQueryable<TransactionsModel>)?.Count() ?? 0);
        }

        [Fact]
        public void Summary()
        {
            TransactionsSummaryModel transactionSummary = new() { TotalItems = 1, TotalValue = 100 };

            QueryParametersModel parameters = new();

            transactionServiceMock.Setup(p => p.Summary(parameters)).Returns(transactionSummary);

            TransactionsController controller = new(transactionServiceMock.Object);
            var result = controller.Summary(parameters) as ObjectResult;

            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);
            Assert.IsType(transactionSummary.GetType(), result?.Value);
            Assert.Equal(StatusCodes.Status200OK, result?.StatusCode);

            Assert.Equal(transactionSummary.TotalItems, (result?.Value as TransactionsSummaryModel)?.TotalItems ?? 0);
            Assert.Equal(transactionSummary.TotalValue, (result?.Value as TransactionsSummaryModel)?.TotalValue ?? 0);
        }
    }
}