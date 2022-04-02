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


        [HttpGet, Route("[action]")]
        public IActionResult TransactionTypes()
        {
            try
            {
                return Ok(catalogService.ListTransactionTypes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}