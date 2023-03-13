using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Security.Cookie.Migration.Infrastructure.Contexts;
using Security.Cookie.Migration.Application;
using Security.Cookie.Migration.Infrastructure;
using Security.Cookie.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Security.Cookie.Domain.Entitties;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        var connectionString = Environment.GetEnvironmentVariable("Cookie.SQL");

        services.AddDbContext<UserDbMigrationContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(connectionString));

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<UserDbMigrationContext>();

        services.RegisterMigrationApplicationPackages();
        services.RegisterMigrationInfrastructurePackages();
    })
    .Build();

host.Run();
