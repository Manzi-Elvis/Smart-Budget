using SmartBudget.Application.DTOs;

namespace SmartBudget.Application.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseDto>> GetExpensesForUserAsync(Guid userId);
        Task<Guid> CreateExpenseAsync(CreateExpenseDto dto);
    }
}
