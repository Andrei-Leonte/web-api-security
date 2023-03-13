using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Security.Cookie.Infrastructure.Contexts;
using Security.Cookie.Migration.Infrastructure.Contexts;

namespace Security.Cookie.Migration.Infrastructure.Factories
{
    public class UserDbMigrationContextFactory : IDesignTimeDbContextFactory<UserDbMigrationContext>
    {
        public UserDbMigrationContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("Cookie.SQL");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new UserDbMigrationContext(optionsBuilder.Options);
        }
    }
}
