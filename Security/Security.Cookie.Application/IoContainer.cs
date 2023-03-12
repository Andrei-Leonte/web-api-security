using Microsoft.Extensions.DependencyInjection;
using Security.Cookie.Application.Interfaces.Services;
using Security.Cookie.Application.Services;

namespace Security.Cookie.Application
{
    public static class IoContainer
    {
        public static void RegistersApplicationPackages(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAccountSignInService, AccountSignInService>();
        }
    }
}
