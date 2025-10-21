using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBudget.Application.DTOs;
using SmartBudget.Application.Services;

namespace SmartBudget.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _svc;

        public ExpensesController(IExpenseService svc)
        {
            _svc = svc;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserExpenses(Guid userId)
        {
            var list = await _svc.GetExpensesForUserAsync(userId);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpenseDto dto)
        {
            var id = await _svc.CreateExpenseAsync(dto);
            return CreatedAtAction(nameof(GetUserExpenses), new { userId = dto.UserId }, new { id });
        }
    }
}
