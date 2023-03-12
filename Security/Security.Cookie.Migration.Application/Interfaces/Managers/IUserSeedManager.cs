namespace Security.Cookie.Migration.Application.Interfaces.Managers
{
    public interface IUserSeedManager
    {
        Task AddAsync(Stream stream);
    }
}