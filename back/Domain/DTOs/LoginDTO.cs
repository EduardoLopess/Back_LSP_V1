using Domain.Enums;

namespace Domain.DTOs
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ProfileAcess ProfileAcess { get; set; }
    }
}