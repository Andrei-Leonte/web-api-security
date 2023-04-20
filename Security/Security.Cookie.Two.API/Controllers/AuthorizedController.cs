using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Security.Cookie.Two.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizedController : ControllerBase
    {
        [Authorize, HttpGet, Route("test1")]
        public IActionResult Test1()
        {
            return Ok();
        }

        [AllowAnonymous, HttpGet, Route("test2")]
        public IActionResult Test2()
        {
            return Ok();
        }
    }
}
