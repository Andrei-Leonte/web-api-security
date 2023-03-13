﻿using Security.Cookie.Migration.Application.Interfaces.Services;
using Security.Cookie.Migration.Infrastructure.Interfaces.Contexts;

namespace Security.Cookie.Migration.Application.Services
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