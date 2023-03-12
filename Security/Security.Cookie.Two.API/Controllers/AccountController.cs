using Microsoft.AspNetCore.Mvc;
using Security.Cookie.Application.Dtos.Accounts.Registers;
using Security.Cookie.Application.Dtos.Accounts.SignIns;
using Security.Cookie.Application.Interfaces.Services;

namespace Security.Cookie.Two.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountSignInService accountSignInManagerService;
        private readonly ILogger<AccountController> logger;

        public AccountController(
            IAccountSignInService accountSignInManagerService, ILogger<AccountController> logger)
            => (this.accountSignInManagerService, this.logger) = (accountSignInManagerService, logger);

        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync(RequestSignInDto requestDto)
        {
            try
            {
                var responseDto = await accountSignInManagerService.SignInAsync(requestDto);

                return Ok(responseDto);
            }
            catch (Exception e)
            {
                logger.LogCritical(e.ToString());

                return BadRequest();
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RequestRegisterDto requestDto)
        {
            try
            {
                await accountSignInManagerService.RegisterAsync(requestDto);

                return Ok();
            }
            catch (Exception e)
            {
                logger.LogCritical(e.ToString());

                return BadRequest();
            }
        }

    }
}
