using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Security.Cookie.Two.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSPController : ControllerBase
    {
        [AllowAnonymous, HttpGet, Route("add")]
        public IActionResult AddCSPHeader()
        {
            Response.Headers.Add("CSP", "connect-src https://localhost:2110; default-src https://localhost:2110; script-src https://localhost:2111; style-src https://localhost:2111; img-src https://localhost:2111; report-uri https://localhost:2111/api/csp/violation");
            Response.Headers.Add("Access-Control-Expose-Headers", "CSP");

            return Ok();
        }

        [AllowAnonymous, HttpPost, Route("violation")]
        public IActionResult violation()
        {
            return Ok();
        }
    }
}
