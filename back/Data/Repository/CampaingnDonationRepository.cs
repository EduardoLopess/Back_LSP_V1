using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class CampaingnDonationRepository : ICampaingnDonationRepository
    {
        private readonly DataContext _context;
        public CampaingnDonationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(CampaingnDonation entity, Address address)
        {
            entity.Address = address;
            _context.Add(entity);

            await _context.SaveChangesAsync();
        }


        public async Task<IList<CampaingnDonation>> GetAllAsync()
        {
            return
                await _context.CampaingnDonations
                    .Include(a => a.Address)
                    .ToListAsync();
        }

        public async Task<CampaingnDonation> GetByIdAsync(int entityId)
        {
              return
                    await _context.CampaingnDonations
                        .Include(a => a.Address)
                        .SingleOrDefaultAsync(d => d.Id == entityId);
        }

        public async Task UpdateAsync(CampaingnDonation entity)
        {
            var existCampaingnDonation = await _context.CampaingnDonations
                                        .Include(a => a.Address)
                                        .SingleOrDefaultAsync(d => d.Id == entity.Id);

            if(existCampaingnDonation != null)
            {
                _context.Entry(existCampaingnDonation).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int entityId)
        {
               var existCampaingnDonation = await _context.CampaingnDonations
                                        .Include(a => a.Address)
                                        .SingleOrDefaultAsync(d => d.Id == entityId);

            if(existCampaingnDonation != null)
            {
                _context.CampaingnDonations.Remove(existCampaingnDonation);
                await
                    _context.SaveChangesAsync();
            }
        }

    }
}