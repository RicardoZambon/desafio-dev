using ByCoders.Importer.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ByCoders.Importer.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class FileManagementController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public FileManagementController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }


        /// <summary>
        /// Upload and import text file with transactions. The file must be in the POST Form.
        /// </summary>
        /// <response code="200">File sucessfully imported.</response>
        /// <response code="400">Provided file is not in correct format.</response>
        /// <response code="400">Internal server issue.</response>
        [HttpPost, Route("[action]"), RequestSizeLimit(4194304)]
        public async Task<IActionResult> Upload()
        {
            try
            {
                if (Request.Form.Files.Any())
                {
                    await transactionService.ImportTransactionsFromFile(Request.Form.Files[0]);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}