using Microsoft.EntityFrameworkCore;
using SmartBudget.Core.Entities;
using SmartBudget.Infrastructure.Persistence;

namespace SmartBudget.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db) => _db = db;

        public async Task AddAsync(User u)
        {
            _db.Users.Add(u);
            await _db.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
