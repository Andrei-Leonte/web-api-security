using Microsoft.Extensions.DependencyInjection;
using Security.Duende.Identity.Server.Migration.Application.Interfaces.Managers;
using Security.Duende.Identity.Server.Migration.Application.Interfaces.Services;
using Security.Duende.Identity.Server.Migration.Application.Managers;
using Security.Duende.Identity.Server.Migration.Application.Services;

namespace Security.Duende.Identity.Server.Migration.Application
{
    public static class IoContainer
    {
        public static void RegisterMigrationApplicationPackages(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserSeedManager, UserSeedManager>();
            serviceCollection.AddScoped<IUserSeedService, UserSeedService>();
            serviceCollection.AddScoped<IUserMigrationService, UserMigrationService>();
        }
    }
}

