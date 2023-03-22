using Security.Duende.Identity.Server.Migration.Application.Dtos;

namespace Security.Duende.Identity.Server.Migration.Application.Interfaces.Managers
{
    public interface IUserSeedManager
    {
        Task<IEnumerable<AddUserSeedDto>> GetDtosAsync(Stream stream);
        Task AddAsync(IEnumerable<AddUserSeedDto> dtos);
    }
}