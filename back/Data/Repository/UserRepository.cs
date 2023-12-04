using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User entity, Address address)
        {
            if(await IsEmailRegisteredAsync(entity.Email))
            {
                throw new InvalidOperationException
                (
                    "Email já está em uso. Por favor, informe um email diferente."
                );
            }

            entity.Addresses = new List<Address> { address };
            _context.Add(entity);
            await
                _context.SaveChangesAsync();
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return
                await _context.Users
                    .Include(a => a.Addresses)
                    .ToListAsync();
        }

        public async Task<User> GetByIdAsync(int entityId)
        {
            return
                await _context.Users
                    .Include(a => a.Addresses)
                    .SingleOrDefaultAsync(u => u.Id == entityId);
        }

        public async Task UpdateAsync(User entity)
        {
            var existingUser = await _context.Users
                              .Include(a => a.Addresses)
                              .FirstOrDefaultAsync(a => a.Id == entity.Id);
            
            if(existingUser != null)
            {
                _context.Entry(existingUser).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int entityId)
        {
            var existingUser = await _context.Users
                            .Include(a => a.Addresses)
                            .FirstOrDefaultAsync(a => a.Id == entityId);
            
            if(existingUser != null)
            {
                _context.Users.Remove(existingUser);
                await
                    _context.SaveChangesAsync();
            } 
        }

        //Valida Email
        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            return
                await _context.Users.AnyAsync(e => e.Email == email);
        }

      
    }
}