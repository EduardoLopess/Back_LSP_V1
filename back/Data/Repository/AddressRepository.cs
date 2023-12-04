using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;
        public AddressRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Address entity)
        {
            _context.Addresses.Add(entity);
            await
                _context.SaveChangesAsync();
        }

        public async Task<IList<Address>> GetAllAsync()
        {
            return
                await _context.Addresses
                    .Include(u => u.Users)
                    .ToListAsync();
        }

        public async Task<Address> GetByIdAsync(int entityId)
        {
            return 
                await _context.Addresses
                    .Include(u => u.Users)
                    .SingleOrDefaultAsync(u => u.Id == entityId);
        }

        public async Task UpdateAsync(Address entity)
        {
            var existingAddress = await _context.Addresses
                                .Include(u => u.Users)
                                .FirstOrDefaultAsync(u => u.Id == entity.Id);
            if(existingAddress != null)
            {
                _context.Entry(existingAddress).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }                    
        }
        
        public async Task DeleteAsync(int entityId)
        {
            var existingAddress = await _context.Addresses
                                .Include(u => u.Users)
                                .FirstOrDefaultAsync(u => u.Id == entityId);
            if(existingAddress != null)
            {
                _context.Addresses.Remove(existingAddress);
                await
                    _context.SaveChangesAsync();
            }                    
        }
    }
}