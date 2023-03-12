using System.Diagnostics.CodeAnalysis;

namespace Security.Cookie.Application.Dtos.Accounts.SignIns
{
    public class RequestSignInDto
    {
        [AllowNull]
        public string Email { get; set; }

        [AllowNull]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
