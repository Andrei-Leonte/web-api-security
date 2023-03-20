using Microsoft.EntityFrameworkCore;
using Security.Duende.Identity.Server.Infrastructure.Contexts;
using Security.Duende.Identity.Server.Migration.Infrastructure.Interfaces.Contexts;

namespace Security.Duende.Identity.Server.Migration.Infrastructure.Contexts
{
    public class UserDbMigrationContext : ApplicationDbContext, IUserDbMigrationContext
    {
        public UserDbMigrationContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public async Task MigrateAsync()
        {
            await Database.MigrateAsync();
        }
    }
}

