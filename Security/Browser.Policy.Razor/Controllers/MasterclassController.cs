using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Browser.Policy.Razor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterclassController : ControllerBase
    {
        [EnableRateLimiting("fixed")]
        [HttpGet("place")]
        public IActionResult Place()
        {
            return new OkObjectResult("USV");
        }
    }
}
