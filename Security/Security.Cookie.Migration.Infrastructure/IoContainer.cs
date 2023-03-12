using Microsoft.Extensions.DependencyInjection;
using Security.Cookie.Migration.Infrastructure.Contexts;
using Security.Cookie.Migration.Infrastructure.Interfaces.Contexts;

namespace Security.Cookie.Migration.Infrastructure
{
    public static class IoContainer
    {
        public static void RegisterMigrationPackages(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserDbMigrationContext, UserDbMigrationContext>();
        }
    }
}
