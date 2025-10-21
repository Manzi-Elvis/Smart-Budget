using SmartBudget.Application.DTOs;
using SmartBudget.Infrastructure.Repositories;
using SmartBudget.Core.Entities;

namespace SmartBudget.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repo;

        public ExpenseService(IExpenseRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> CreateExpenseAsync(CreateExpenseDto dto)
        {
            var e = new Expense
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                Category = dto.Category,
                Amount = dto.Amount,
                Date = DateTime.UtcNow,
                Description = dto.Description ?? string.Empty
            };

            await _repo.AddAsync(e);
            return e.Id;
        }

        public async Task<IEnumerable<ExpenseDto>> GetExpensesForUserAsync(Guid userId)
        {
            var list = await _repo.ListByUserAsync(userId);
            return list.Select(x => new ExpenseDto(x.Id, x.UserId, x.Category, x.Amount, x.Date, x.Description));
        }
    }
}
