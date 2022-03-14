using Core.Exceptions;
using Core.Interfaces;
using Core.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TechnicalTestITSense_APIRest.Utilities.Handlers;

namespace TechnicalTestITSense_APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productservice;
        public ProductsController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _productservice.GetProducts());


        [HttpGet("{idProduct}")]
        public async Task<IActionResult> Get(long idProduct)
        {
            if (idProduct == 0)
                throw new HttpException(new List<string> { "idProduct cannot be 0" }, HttpStatusCode.BadRequest);

            return Ok(await _productservice.GetProductById(idProduct));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string nameProduct)
        {
            if (nameProduct == null)
                throw new HttpException(new List<string> { "nameProduct annot be 0" }, HttpStatusCode.NotFound);
            return Ok(await _productservice.CreateProduct(nameProduct));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDTO updateProductDTO)
        {
            ModelState.ModelStateValid();
            if (updateProductDTO == null)
                throw new HttpException(new List<string> { "Data model cannot be null" }, HttpStatusCode.BadRequest);
            return Ok(await _productservice.UpdateProduct(updateProductDTO));
        }

        [HttpPatch("{idProduct}/{idSatatusProduct}")]
        public async Task<IActionResult> Patch(long idProduct, int idSatatusProduct)
        {
            if (idProduct == 0 || idSatatusProduct == 0 || idSatatusProduct > 4)
                throw new HttpException(new List<string> { "idProduct or idSatatusProduct cannot be 0 and idSatatusProduct only accept 1,2,3 and 4 " }, HttpStatusCode.BadRequest);
            return Ok(await _productservice.ChangeStateProduct(idProduct, idSatatusProduct));
        }
    }
}
