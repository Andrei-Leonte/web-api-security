using Microsoft.AspNetCore.Identity;
using Security.Cookie.Domain.Entitties;
using Security.Cookie.Migration.Application.Dtos;
using System.Text.Json;
using Security.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Security.Cookie.Migration.Domain.Exceptions;
using Security.Utils.Misc.Consts;
using Security.Cookie.Migration.Application.Interfaces.Services;

namespace Security.Cookie.Migration.Application.Services
{
    public class UserSeedService : IUserSeedService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserSeedService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
            => (this.userManager, this.roleManager) = (userManager, roleManager);

        public async Task<IEnumerable<AddUserSeedDto>> GetDtoAsync(Stream stream)
        {
            var jsonBody = await stream.ReasAsStringAsync();

            var dtos = JsonSerializer
                .Deserialize<IEnumerable<AddUserSeedDto>>(jsonBody);

            if (dtos is null)
            {
                throw new InvalidDataException();
            }

            return dtos;
        }

        public async IAsyncEnumerable<ApplicationUser> AddAsync(IEnumerable<AddUserSeedDto> dtos)
        {
            var users = await userManager.Users.ToListAsync();

            if (users.Count > 0)
            {
                throw new UserAlreadyExistException();
            }

            foreach (var dto in dtos)
            {
                var eNotarUser = new ApplicationUser(dto.Email, dto.FirstName, dto.LastName);

                var result = await userManager.CreateAsync(eNotarUser, dto.Password);

                if (!result.Succeeded)
                {
                    throw new UnableToAddUserException(
                        $"Unable to add user {result.Errors.Select(r => r.Description)}");
                }

                yield return eNotarUser;
            }
        }

        public async Task AddAdminRoleAsync()
        {
            var role = new IdentityRole(UserRoleConst.Admin);

            var result = await roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                throw new UnableToAddRoleException(
                    $"Unable to assign role {result.Errors.Select(r => r.Description)})");
            }

            await roleManager.AddClaimAsync(
                role,
                new Claim(UserClaimConst.Permission, UserClaimValueConst.AdminRead));

            await roleManager.AddClaimAsync(
                role,
                new Claim(UserClaimConst.Permission, UserClaimValueConst.AdminWrite));

            await roleManager.AddClaimAsync(
                role,
                new Claim(UserClaimConst.Permission, UserClaimValueConst.AdminDelete));
        }

        public async Task AssignRole(ApplicationUser applicationUser)
        {
            var result = await userManager.AddToRoleAsync(applicationUser, UserRoleConst.Admin);

            if (!result.Succeeded)
            {
                throw new UnableToAssignRoleException(
                    $"Unable to assign role {result.Errors.Select(r => r.Description)})");
            }
        }

        public async Task AssignClaims(ApplicationUser applicationUser)
        {
            var claims = new List<Claim>()
            {
                new Claim(UserClaimConst.Email, applicationUser.Email!),
                new Claim(UserClaimConst.Name, applicationUser.GetName())
            };

            var result = await userManager.AddClaimsAsync(applicationUser, claims);

            if (!result.Succeeded)
            {
                throw new UnableToAddClaimException(
                    $"Unable to create claims {result.Errors.Select(r => r.Description)})");
            }
        }

    }
}
