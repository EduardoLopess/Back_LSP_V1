using Domain.DTOs;

namespace Domain.Interfaces
{
    public interface ILoginRepository
    {
        Task<UserDTO> UserLoginAsync(LoginDTO loginCredentials);
        //Task<InstituteDTO> InstituteLoginAsync(LoginDTO loginCredentials);

        Task<bool> UserLogoutAsync(int userId);
        //Task<bool> InstituteLogoutAsync(int instituteId);
        Task<bool> RecoverPasswordAsync(string email);
    }
}