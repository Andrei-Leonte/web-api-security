using Microsoft.Extensions.DependencyInjection;
using Security.Cookie.Migration.Application.Interfaces.Managers;
using Security.Cookie.Migration.Application.Interfaces.Services;
using Security.Cookie.Migration.Application.Managers;
using Security.Cookie.Migration.Application.Services;

namespace Security.Cookie.Migration.Application
{
    public static class IoContainer
    {
        public static void RegisterMigrationPackages(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserSeedManager, UserSeedManager>();
            serviceCollection.AddScoped<IUserSeedService, UserSeedService>();
        }
    }
}

