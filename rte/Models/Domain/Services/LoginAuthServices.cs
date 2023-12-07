using Domain.Enums;

namespace Domain.Services
{
    public class LoginAuthServices
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ProfileAcess ProfileAcess { get; set; }
        public int UserId { get; set; }
    }
}