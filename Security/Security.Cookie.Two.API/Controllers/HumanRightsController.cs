using Microsoft.AspNetCore.Mvc;

namespace Security.Cookie.Two.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class HumanRightsController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("self")]
        public IActionResult Get() => new OkObjectResult("You are {}");
    }
}
