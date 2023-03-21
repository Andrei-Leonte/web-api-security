using Duende.IdentityServer.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Security.Duende.Identity.Server.Migration.Infrastructure.Interfaces.Contexts;

namespace Security.Duende.Identity.Server.Migration.Infrastructure.Contexts
{
    public class ConfigurationDbContextMigration : ConfigurationDbContext, IConfigurationDbContextMigration
    {
        public ConfigurationDbContextMigration(DbContextOptions<ConfigurationDbContext> options) : base(options)
        {
        }

        public async Task MigrateAsync()
        {
            await Database.MigrateAsync();
        }
    }
}
