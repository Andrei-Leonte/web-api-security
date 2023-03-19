using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Security.Cookie.Two.API.Controllers
{
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [Authorize]
    public class HumanRightsController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public HumanRightsController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        //[MapToApiVersion("1.0")]
        [Route("self")]
        public IActionResult Get() => new OkObjectResult("You are {}");


        [HttpGet]
        //[MapToApiVersion("1.0")]
        [Route("test")]
        public IActionResult GetTest()
        {
            var identities = httpContextAccessor.HttpContext.Request;

            return new OkObjectResult("Ok");
        }
    }
}
