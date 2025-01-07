using Microsoft.AspNetCore.Mvc;

namespace VirtualMarketplace.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public IActionResult HelloWorld()
        {
            return Ok("Hello World!");
        }
    }
}
