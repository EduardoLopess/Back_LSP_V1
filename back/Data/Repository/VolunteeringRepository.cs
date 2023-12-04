using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class VolunteeringRepository : IVolunteeringRepository
    {
        private readonly DataContext _context;
        public VolunteeringRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Volunteering entity, List<string> responsibilities, List<string> benefits, Address address)
        {
            entity.Responsibilities = responsibilities;
            entity.Benefits = benefits;
            entity.Address = address;
            
            _context.Add(entity);

            await _context.SaveChangesAsync(); 
        }
        public async Task<IList<Volunteering>> GetAllAsync()
        {
            return
                await _context.Volunteerings
                .Include(a => a.Address)
                .ToListAsync();
        }

        public async Task<Volunteering> GetByIdAsync(int entityId)
        {
            return await _context.Volunteerings
                .Include(a => a.Address)
                .SingleOrDefaultAsync(v => v.Id == entityId);
        }
        public async Task UpdateAsync(Volunteering entity)
        {
            var existeVolunteering = await _context.Volunteerings
                                    .Include(a => a.Address)
                                    .FirstOrDefaultAsync(a => a.Id == entity.Id);
            if(existeVolunteering != null)
            {
                _context.Entry(existeVolunteering).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int entityId)
        {
             var existeVolunteering = await _context.Volunteerings
                                    .Include(a => a.Address)
                                    .FirstOrDefaultAsync(a => a.Id == entityId);

            if(existeVolunteering != null)
            {
                _context.Volunteerings.Remove(existeVolunteering);
                await
                    _context.SaveChangesAsync();
            }                         
        }

        public async Task SingUpForVolunteering(int userId, int volunteeringId)
        {
            var volunteeringRegistration = new VolunteeringRegistration
            {
                UserId = userId,
                VolunteeringId = volunteeringId,
                RegistrationDate = DateTime.UtcNow
            };
            _context.VolunteeringRegistrations.Add(volunteeringRegistration);
            await _context.SaveChangesAsync();
        }

    }
}