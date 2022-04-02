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


        [HttpPost, Route("[action]")]
        public async Task<IActionResult> List(QueryParametersModel parameters)
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
                return BadRequest(ex.Message);
            }
        }

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
                return BadRequest(ex.Message);
            }
        }
    }
}