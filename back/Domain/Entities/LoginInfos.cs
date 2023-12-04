using Domain.Enums;

namespace Domain.Entities
{
    public abstract class LoginInfos
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ProfileAcess ProfileAcess { get; set; }
    }
}