using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IVolunteeringRepository : IBaseRepository<Volunteering>
    {
        Task CreateAsync(Volunteering entity, List<string> responsibilities, List<string> benefits, Address address );
        Task SingUpForVolunteering(int userId, int volunteeringId);
    }
}