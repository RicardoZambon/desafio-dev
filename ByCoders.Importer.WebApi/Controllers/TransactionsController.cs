using ByCoders.Importer.Core.Exceptions;
using ByCoders.Importer.WebApi.Models;
using ByCoders.Importer.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ByCoders.Importer.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }


        /// <summary>
        /// Returns the list of transactions.
        /// </summary>
        /// <param name="parameters">Parameters to display the transactions list with start range, end range, filters, and sort.</param>
        /// <returns>The transactions list.</returns>
        /// <response code="200">List sucessfully returned.</response>
        /// <response code="401">Missing parameter.</response>
        /// <response code="400">Internal server issue.</response>
        [HttpPost, Route("[action]")]
        public IActionResult List(QueryParametersModel parameters)
        {
            try
            {
                return Ok(transactionService.List(parameters));
            }
            catch (MissingQueryParametersException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Returns the summary of the transactions (items count and value amount).
        /// </summary>
        /// <param name="parameters">Parameters to filter and calculate the summary.</param>
        /// <returns>The summary with the items count and value amount.</returns>
        /// <response code="200">Summary sucessfully returned.</response>
        /// <response code="401">Missing parameter.</response>
        /// <response code="400">Internal server issue.</response>
        [HttpPost, Route("[action]")]
        public IActionResult Summary(SummaryParametersModel parameters)
        {
            try
            {
                return Ok(transactionService.Summary(parameters));
            }
            catch (MissingQueryParametersException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}