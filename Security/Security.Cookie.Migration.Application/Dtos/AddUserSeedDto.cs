namespace Security.Cookie.Migration.Application.Dtos
{
    public record AddUserSeedDto(
        string Email,
        string Password,
        string PhoneNumber,
        string FirstName,
        string LastName,
        List<string> Roles);
}
