using Microsoft.Extensions.DependencyInjection;
using Security.Duende.Identity.Server.Migration.Infrastructure.Contexts;
using Security.Duende.Identity.Server.Migration.Infrastructure.Interfaces.Contexts;

namespace Security.Duende.Identity.Server.Migration.Infrastructure
{
    public static class IoContainer
    {
        public static void RegisterMigrationInfrastructurePackages(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserDbMigrationContext, UserDbMigrationContext>();
        }
    }
}
