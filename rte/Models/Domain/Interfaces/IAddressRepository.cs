using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task CreateAsync(Address entity);
    }
}