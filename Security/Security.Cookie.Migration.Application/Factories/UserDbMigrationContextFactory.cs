using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Security.Cookie.Infrastructure.Contexts;
using Security.Cookie.Migration.Infrastructure.Contexts;

namespace Security.Cookie.Migration.Application.Factories
{
    public class UserDbMigrationContextFactory : IDesignTimeDbContextFactory<UserDbMigrationContext>
    {
        public UserDbMigrationContext CreateDbContext(string[] args)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    //.SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("local.settings.json")
            //    .Build();

            //var connectionString = configuration.GetConnectionString("ENotarUserDbConnectionString");

            var connectionString = Environment.GetEnvironmentVariable("Cookie.SQL");

            //var connectionString = "server=localhost; database=identity; user=root; password=notar";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new UserDbMigrationContext(optionsBuilder.Options);
        }
    }
}
