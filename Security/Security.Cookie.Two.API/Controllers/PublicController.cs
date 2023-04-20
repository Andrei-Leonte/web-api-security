using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Security.Cookie.Two.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous, HttpGet, Route("usv")]
        public IActionResult Test2()
        {
            return Ok();
        }
    }
}
