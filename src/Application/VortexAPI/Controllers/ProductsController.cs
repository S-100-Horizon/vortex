using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static VortexAPI.ProductsCommandController;

namespace VortexAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductsCommandController _commandController;

        public ProductsController(ILogger<ProductsController> logger, ProductsCommandController commandController) {
            _logger = logger;
            _commandController = commandController;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(DateTime.Now);
        }

        [HttpPut("{productId}")]
        public IActionResult Put(string productId) {
            if (string.IsNullOrEmpty(productId)) return BadRequest();

            _commandController.Handle<CreateProduct>(new CreateProduct(productId), CancellationToken.None);

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
