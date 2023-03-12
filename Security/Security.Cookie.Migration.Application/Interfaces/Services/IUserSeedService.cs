using Security.Cookie.Domain.Entitties;
using Security.Cookie.Migration.Application.Dtos;

namespace Security.Cookie.Migration.Application.Interfaces.Services
{
    public interface IUserSeedService
    {
        Task AddAdminRoleAsync();
        IAsyncEnumerable<ApplicationUser> AddAsync(IEnumerable<AddUserSeedDto> dtos);
        Task AssignClaims(ApplicationUser applicationUser);
        Task AssignRole(ApplicationUser applicationUser);
        Task<IEnumerable<AddUserSeedDto>> GetDtoAsync(Stream stream);
    }
}