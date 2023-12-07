using Domain.DTOs;
using Domain.Interfaces;

namespace Data.Repository
{
    public class LoginAuthRepository : ILoginRepository
    {
        public Task<bool> RecoverPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UserLoginAsync(LoginDTO loginCredentials)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserLogoutAsync(int userId)
        {
            throw new NotImplementedException();
        }

    }
}       	    	    	