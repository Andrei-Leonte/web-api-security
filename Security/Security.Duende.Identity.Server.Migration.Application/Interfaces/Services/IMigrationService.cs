namespace Security.Duende.Identity.Server.Migration.Application.Interfaces.Services
{
    public interface IMigrationService
    {
        Task UpdateUserDatabaseAsync();
        Task UpdatePersistentGrantDatabaseAsync();
        Task UpdateConfigurationDatabaseAsync();
    }
}