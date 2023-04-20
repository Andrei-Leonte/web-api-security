using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Security.Cookie.Two.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public TestController(IHttpContextAccessor httpContextAccessor)
            => this.httpContextAccessor = httpContextAccessor;

        [Authorize, HttpGet, Route("test1")]
        public IActionResult Test1()
        {
            return Ok("You are authorized!");
        }

        [AllowAnonymous, HttpGet, Route("test2")]
        public IActionResult Test2()
        {
            return Ok("Public request!");
        }
    }
}
