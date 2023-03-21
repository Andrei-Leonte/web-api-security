namespace Security.Duende.Identity.Server.Migration.Infrastructure.Interfaces.Contexts
{
    public interface IPersistenGrantDbMigrationContext
    {
        Task MigrateAsync();
    }
}