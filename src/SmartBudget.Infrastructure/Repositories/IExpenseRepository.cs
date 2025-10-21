using SmartBudget.Core.Entities;

namespace SmartBudget.Infrastructure.Repositories
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense e);
        Task<IEnumerable<Expense>> ListByUserAsync(Guid userId);
    }
}
