using Security.Duende.Identity.Server.Migration.Application.Interfaces.Services;
using Security.Duende.Identity.Server.Migration.Infrastructure.Interfaces.Contexts;

namespace Security.Duende.Identity.Server.Migration.Application.Services
{
    public class UserMigrationService : IUserMigrationService
    {
        private readonly IUserDbMigrationContext userDbMigrationContext;

        public UserMigrationService(IUserDbMigrationContext userDbMigrationContext)
            => this.userDbMigrationContext = userDbMigrationContext;

        public async Task AddAsync()
        {
            await userDbMigrationContext.MigrateAsync();
        }
    }
}
