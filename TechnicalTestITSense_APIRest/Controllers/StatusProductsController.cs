using Core.Interfaces.StatusProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TechnicalTestITSense_APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusProductsController : ControllerBase
    {
        private readonly IStatusProductService _statusProductService;
        public StatusProductsController(IStatusProductService statusProductService)
        {
            _statusProductService = statusProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatusProducts() => Ok(await _statusProductService.GetSatusProduct());
    }
}
