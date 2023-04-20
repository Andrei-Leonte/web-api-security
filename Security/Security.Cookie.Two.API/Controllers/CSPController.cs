﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Security.Cookie.Two.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSPController : ControllerBase
    {
        [AllowAnonymous, HttpGet, Route("add")]
        public IActionResult Test2()
        {
            return Ok("something!");
        }
    }
}
