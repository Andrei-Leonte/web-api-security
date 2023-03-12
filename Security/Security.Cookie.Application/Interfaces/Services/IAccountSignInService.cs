using Security.Cookie.Application.Dtos.Accounts.Registers;
using Security.Cookie.Application.Dtos.Accounts.SignIns;

namespace Security.Cookie.Application.Interfaces.Services
{
    public interface IAccountSignInService
    {
        Task<ResponseSignInDto> SignInAsync(RequestSignInDto dto);
        Task RegisterAsync(RequestRegisterDto dto);
    }
}
