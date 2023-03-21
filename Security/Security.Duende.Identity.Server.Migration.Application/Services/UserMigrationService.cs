using Security.Duende.Identity.Server.Migration.Application.Interfaces.Services;
using Security.Duende.Identity.Server.Migration.Infrastructure.Interfaces.Contexts;

namespace Security.Duende.Identity.Server.Migration.Application.Services
{
    public class MigrationService : IMigrationService
    {
        private readonly IUserDbMigrationContext userDbMigrationContext;
        private readonly IPersistenGrantDbMigrationContext persistenGrantDbMigrationContext;
        private readonly IConfigurationDbContextMigration configurationDbContextMigration;

        public MigrationService(
            IUserDbMigrationContext userDbMigrationContext,
            IPersistenGrantDbMigrationContext persistenGrantDbMigrationContext,
            IConfigurationDbContextMigration configurationDbContextMigration)
        {
            this.userDbMigrationContext = userDbMigrationContext;
            this.persistenGrantDbMigrationContext = persistenGrantDbMigrationContext;
            this.configurationDbContextMigration = configurationDbContextMigration;
        }

        public async Task UpdateUserDatabaseAsync()
        {
            await userDbMigrationContext.MigrateAsync();
        }

        public async Task UpdatePersistentGrantDatabaseAsync()
        {
            await persistenGrantDbMigrationContext.MigrateAsync();
        }

        public async Task UpdateConfigurationDatabaseAsync()
        {
            await configurationDbContextMigration.MigrateAsync();
        }
    }
}
