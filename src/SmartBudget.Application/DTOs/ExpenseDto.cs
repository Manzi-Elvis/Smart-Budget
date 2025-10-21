namespace SmartBudget.Application.DTOs
{
    public record ExpenseDto(Guid Id, Guid UserId, string Category, decimal Amount, System.DateTime Date, string Description);
}
