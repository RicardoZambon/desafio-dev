using ByCoders.Importer.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ByCoders.Importer.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class CatalogsController : ControllerBase
    {
        private readonly ICatalogService catalogService;

        public CatalogsController(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }


        /// <summary>
        /// Display a list of available transaction types.
        /// </summary>
        /// <returns>The transaction types.</returns>
        /// <response code="200">List returned successfully.</response>
        /// <response code="400">Internal server issue.</response>
        [HttpGet, Route("[action]")]
        public IActionResult TransactionTypes()
        {
            try
            {
                return Ok(catalogService.ListTransactionTypes());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}