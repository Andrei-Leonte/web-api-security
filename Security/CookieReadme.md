1. Add new migration using folder ../Security.Cookie.Migration.Infrastructure

```powershell
dotnet tool install --global dotnet-ef --version 7.0.4
$env:ASPNETCORE_ENVIRONMENT='Production'
dotnet ef migrations add InitialCreate --startup-project ../Security.Cookie.Migration.Function --context UserDbMigrationContext --output-dir Migrations/Users --verbose
```
