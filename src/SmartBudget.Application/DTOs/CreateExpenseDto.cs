namespace SmartBudget.Application.DTOs
{
    public record CreateExpenseDto(Guid UserId, string Category, decimal Amount, string? Description);
}
