using Security.Duende.Identity.Server.Domain.Entities;
using Security.Duende.Identity.Server.Migration.Application.Dtos;

namespace Security.Duende.Identity.Server.Migration.Application.Interfaces.Services
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