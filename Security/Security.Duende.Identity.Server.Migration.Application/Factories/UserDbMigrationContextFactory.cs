using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Security.Duende.Identity.Server.Infrastructure.Contexts;
using Security.Duende.Identity.Server.Migration.Infrastructure.Contexts;

namespace Security.Duende.Identity.Server.Migration.Application.Factories
{
    public class UserDbMigrationContextFactory : IDesignTimeDbContextFactory<UserDbMigrationContext>
    {
        public UserDbMigrationContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("Cookie.SQL");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new UserDbMigrationContext(optionsBuilder.Options);
        }
    }
}
