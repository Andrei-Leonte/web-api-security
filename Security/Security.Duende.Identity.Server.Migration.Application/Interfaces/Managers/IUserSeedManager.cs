namespace Security.Duende.Identity.Server.Migration.Application.Interfaces.Managers
{
    public interface IUserSeedManager
    {
        Task AddAsync(Stream stream);
    }
}