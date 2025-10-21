using Microsoft.EntityFrameworkCore;
using SmartBudget.Core.Entities;
using SmartBudget.Infrastructure.Persistence;

namespace SmartBudget.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _db;
        public ExpenseRepository(AppDbContext db) => _db = db;

        public async Task AddAsync(Expense e)
        {
            _db.Expenses.Add(e);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> ListByUserAsync(Guid userId)
        {
            return await _db.Expenses
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
