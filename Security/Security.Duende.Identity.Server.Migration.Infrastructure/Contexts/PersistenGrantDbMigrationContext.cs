using Duende.IdentityServer.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Security.Duende.Identity.Server.Migration.Infrastructure.Interfaces.Contexts;

namespace Security.Duende.Identity.Server.Migration.Infrastructure.Contexts
{
    public class PersistenGrantDbMigrationContext : PersistedGrantDbContext, IPersistenGrantDbMigrationContext
    {
        public PersistenGrantDbMigrationContext(DbContextOptions<PersistedGrantDbContext> options) : base(options)
        {
        }

        public async Task MigrateAsync()
        {
            await Database.MigrateAsync();
        }
    }
}
