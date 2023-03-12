namespace Security.Cookie.Migration.Infrastructure.Interfaces.Contexts
{
    public interface IUserDbMigrationContext
    {
        Task MigrateAsync();
    }
}
