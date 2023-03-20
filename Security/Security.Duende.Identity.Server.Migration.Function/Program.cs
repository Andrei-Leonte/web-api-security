using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Security.Duende.Identity.Server.Domain.Entities;
using Security.Duende.Identity.Server.Infrastructure.Contexts;
using Security.Duende.Identity.Server.Migration.Application;
using Security.Duende.Identity.Server.Migration.Infrastructure;
using Security.Duende.Identity.Server.Migration.Infrastructure.Contexts;

var host = new HostBuilder()
.ConfigureFunctionsWorkerDefaults()
.ConfigureServices(services =>
    {
        var connectionString = Environment.GetEnvironmentVariable("Duende.SQL");

        services.AddDbContext<UserDbMigrationContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<UserDbMigrationContext>();

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<UserDbMigrationContext>()
            .AddDefaultTokenProviders();

        services
            .AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(
                    connectionString, b => b.MigrationsAssembly("Security.Duende.Identity.Server.Migration.Infrastructure"));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(
                    connectionString, b => b.MigrationsAssembly("Security.Duende.Identity.Server.Migration.Infrastructure"));
            });

        services.RegisterMigrationApplicationPackages();
        services.RegisterMigrationInfrastructurePackages();
    })
.Build();

host.Run();
