namespace Security.Cookie.Application.Dtos.Accounts.Registers
{
    public record RequestRegisterDto
    {
        public RequestRegisterDto(string email, string password, string firstname, string lastname)
        {
            Email = email;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
