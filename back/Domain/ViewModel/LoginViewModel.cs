using Domain.Enums;

namespace Domain.ViewModel
{
    public abstract class LoginViewModel 
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ProfileAcess ProfileAcess { get; set; }
    }
}