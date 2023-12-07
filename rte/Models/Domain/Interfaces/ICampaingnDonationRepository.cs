using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICampaingnDonationRepository : IBaseRepository<CampaingnDonation>
    {
        Task CreateAsync(CampaingnDonation entity, Address address);
    }
}