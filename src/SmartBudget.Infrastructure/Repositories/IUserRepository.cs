using SmartBudget.Core.Entities;

namespace SmartBudget.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User u);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
    }
}
