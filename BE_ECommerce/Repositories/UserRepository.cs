using Microsoft.EntityFrameworkCore;
using BE_ECommerce.Entities;

namespace BE_ECommerce.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<User> CreateAsync(User user)
        {
            await _dbSet.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _dbSet.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user == null) return;

            _dbSet.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
