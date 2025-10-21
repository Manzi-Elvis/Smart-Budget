using SmartBudget.Core.Entities;
using Xunit;

namespace SmartBudget.Tests
{
    public class ExpenseUnitTests
    {
        [Fact]
        public void CanCreateExpense()
        {
            var e = new Expense
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Category = "coffee",
                Amount = 3.50m,
                Description = "morning coffee"
            };

            Assert.Equal("coffee", e.Category);
            Assert.Equal(3.50m, e.Amount);
            Assert.NotEqual(Guid.Empty, e.Id);
        }
    }
}
