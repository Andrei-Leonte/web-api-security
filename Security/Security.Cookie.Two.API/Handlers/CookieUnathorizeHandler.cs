//using Microsoft.AspNetCore.Authentication;
//using Microsoft.Extensions.Options;
//using System.Text.Encodings.Web;

//namespace Security.Cookie.Two.API.Handlers
//{
//    public class CookieUnathorizeHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        public CookieUnathorizeHandler(IOptionsMonitor<AuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) 
//            : base(options, logger, encoder, clock)
//        {
//        }

//        protected override  Task<AuthenticateResult> HandleAuthenticateAsync()
//        {
//            var ticket = new AuthenticationTicket();

//            return AuthenticateResult.Success(ticket);
//        }

//        protected override Task HandleForbiddenAsync(AuthenticationProperties properties)
//        {
//            return base.HandleForbiddenAsync(properties);
//        }
//    }
//}