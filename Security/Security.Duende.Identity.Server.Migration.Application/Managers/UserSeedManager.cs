using Security.Duende.Identity.Server.Migration.Application.Dtos;
using Security.Duende.Identity.Server.Migration.Application.Interfaces.Managers;
using Security.Duende.Identity.Server.Migration.Application.Interfaces.Services;

namespace Security.Duende.Identity.Server.Migration.Application.Managers
{
    public class UserSeedManager : IUserSeedManager
    {
        private readonly IUserSeedService userSeedService;

        public UserSeedManager(IUserSeedService userSeedService)
            => this.userSeedService = userSeedService;

        public async Task<IEnumerable<AddUserSeedDto>> GetDtosAsync(Stream stream)
        {
            return await userSeedService.GetDtoAsync(stream);
        }

        public async Task AddAsync(IEnumerable<AddUserSeedDto> dtos)
        {
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
            catch(Exception e)
            {
                throw new Exception("An error has occured!", e);
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
