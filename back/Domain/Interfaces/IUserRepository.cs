using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task CreateAsync(User entity, Address address);
        Task<bool> IsEmailRegisteredAsync (string email);
    }
}