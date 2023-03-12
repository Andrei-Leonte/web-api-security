using Microsoft.AspNetCore.Identity;
using System.Text;

namespace Security.Cookie.Domain.Entitties
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string email, string firstName, string lastName)
        {
            Email = email;
            UserName = email;
            EmailConfirmed = true;
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }



        public string GetName()
        {
            return new StringBuilder().AppendJoin(" ", FirstName, LastName).ToString();
        }
    }
}
