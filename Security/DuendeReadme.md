1. Add new migration for UserDbMigrationContext using folder ../Security.Duende.Identity.Server.Migration.Infrastructure

```powershell
dotnet tool install --global dotnet-ef --version 7.0.4
$env:ASPNETCORE_ENVIRONMENT='Production'
dotnet ef migrations add InitialCreate --startup-project ../Security.Duende.Identity.Server.Migration.Function --context UserDbMigrationContext --output-dir Migrations/Users --verbose
```

2. Add new migration for ConfigurationDbContext table using folder ../Security.Duende.Identity.Server.Migration.Infrastructure

```powerhsell
$env:ASPNETCORE_ENVIRONMENT='Production'
dotnet ef migrations add InitialCreate --startup-project ../Security.Duende.Identity.Server.Migration.Function --context Duende.IdentityServer.EntityFramework.DbContexts.ConfigurationDbContext --output-dir Migrations/Duende/ConfigurationDb --verbose
```

3. Add new migration for ConfigurationDbContext table using folder ../Security.Duende.Identity.Server.Migration.Infrastructure

```powerhsell
$env:ASPNETCORE_ENVIRONMENT='Production'
dotnet ef migrations add InitialCreate --startup-project ../Security.Duende.Identity.Server.Migration.Function --context Duende.IdentityServer.EntityFramework.DbContexts.PersistedGrantDbContext --output-dir Migrations/Duende/PersistedGrantDb --verbose
```
