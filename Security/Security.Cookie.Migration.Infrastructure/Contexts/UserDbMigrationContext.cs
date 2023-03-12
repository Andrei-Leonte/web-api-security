using Microsoft.EntityFrameworkCore;
using Security.Cookie.Infrastructure.Contexts;
using Security.Cookie.Migration.Infrastructure.Interfaces.Contexts;

namespace Security.Cookie.Migration.Infrastructure.Contexts
{
    internal class UserDbMigrationContext : ApplicationContext, IUserDbMigrationContext
    {
        public UserDbMigrationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public async Task MigrateAsync()
        {
            await Database.MigrateAsync();
        }
    }
}

