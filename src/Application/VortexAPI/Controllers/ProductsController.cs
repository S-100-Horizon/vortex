using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VortexAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(DateTime.Now);
        }

        [HttpPut("{productId}")]
        public IActionResult Put(string productId) {
            if (string.IsNullOrEmpty(productId)) return BadRequest();

            return Ok();
        }
    }
}

namespace VortexAPI.Requests
{
    namespace Products
    {

    }
}

namespace VortexAPI.Responses
{
    namespace Products
    {

    }
}
