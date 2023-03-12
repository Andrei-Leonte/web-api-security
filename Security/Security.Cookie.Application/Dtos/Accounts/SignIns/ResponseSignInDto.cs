namespace Security.Cookie.Application.Dtos.Accounts.SignIns
{
    public class ResponseSignInDto
    {
        public ResponseSignInDto(bool is2FA, bool isLocked = false)
        {
            Is2FA = is2FA;
            IsLocked = isLocked;
        }

        public bool Is2FA { get; set; }
        public bool IsLocked { get; set; }
    }
}
