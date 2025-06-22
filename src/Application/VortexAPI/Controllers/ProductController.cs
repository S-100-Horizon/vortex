using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VortexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger) {
            _logger = logger;
        }
    }
}
