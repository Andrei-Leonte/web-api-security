using Microsoft.AspNetCore.Identity;
using Security.Cookie.Application.Dtos.Accounts.Registers;
using Security.Cookie.Application.Dtos.Accounts.SignIns;
using Security.Cookie.Application.Interfaces.Services;
using Security.Cookie.Domain.Entitties;

namespace Security.Cookie.Application.Services
{
    public class AccountSignInService : IAccountSignInService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountSignInService(
            SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
            => (this.signInManager, this.userManager) = (signInManager, userManager);


        public async Task<ResponseSignInDto> SignInAsync(RequestSignInDto dto)
        {
            var result = await signInManager
                .PasswordSignInAsync(dto.Email, dto.Password, dto.RememberMe, lockoutOnFailure: false)
                .ConfigureAwait(false);

            if (result.Succeeded)
            {
                return new ResponseSignInDto(false);
            }

            if (result.RequiresTwoFactor)
            {
                return new ResponseSignInDto(true);
            }

            if (result.IsLockedOut)
            {
                return new ResponseSignInDto(false, true);
            }

            throw new Exception("Username or password is invalid!");
        }

        public async Task RegisterAsync(RequestRegisterDto dto)
        {
            var user = new ApplicationUser(dto.Email, dto.Firstname, dto.Lastname);

            var result = await userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Usenrame or password is invalid!");
            }
        }
    }
}
