using Security.Cookie.Migration.Application.Interfaces.Managers;
using Security.Cookie.Migration.Application.Interfaces.Services;

namespace Security.Cookie.Migration.Application.Managers
{
    public class UserSeedManager : IUserSeedManager
    {
        private readonly IUserSeedService userSeedService;

        public UserSeedManager(IUserSeedService userSeedService)
            => this.userSeedService = userSeedService;

        public async Task AddAsync(Stream stream)
        {
            var dtos = await userSeedService.GetDtoAsync(stream);

            var users = userSeedService.AddAsync(dtos);
            await userSeedService.AddAdminRoleAsync();

            var eNotarUsersEnumerator = users.GetAsyncEnumerator();

            try
            {
                while (await eNotarUsersEnumerator.MoveNextAsync())
                {

                    await userSeedService.AssignRole(eNotarUsersEnumerator.Current);
                    await userSeedService.AssignClaims(eNotarUsersEnumerator.Current);
                }
            }
            finally
            {
                if (eNotarUsersEnumerator != null)
                {
                    await eNotarUsersEnumerator.DisposeAsync();
                }
            }
        }
    }
}
