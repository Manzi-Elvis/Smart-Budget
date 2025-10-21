using SmartBudget.Application.DTOs;

namespace SmartBudget.Application.Services
{
    public interface IAuthService
    {
        Task<(bool Success, string Message, Guid? UserId)> RegisterAsync(RegisterDto dto);
        Task<(bool Success, string Message, string? Token)> LoginAsync(LoginDto dto);
    }
}
