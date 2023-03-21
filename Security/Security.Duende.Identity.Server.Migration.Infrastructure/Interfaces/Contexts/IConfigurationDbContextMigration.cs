namespace Security.Duende.Identity.Server.Migration.Infrastructure.Interfaces.Contexts
{
    public interface IConfigurationDbContextMigration
    {
        Task MigrateAsync();
    }
}