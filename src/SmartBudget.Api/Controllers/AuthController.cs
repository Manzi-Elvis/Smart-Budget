using Microsoft.AspNetCore.Mvc;
using SmartBudget.Application.DTOs;
using SmartBudget.Application.Services;

namespace SmartBudget.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var res = await _auth.RegisterAsync(dto);
            if (!res.Success) return BadRequest(new { res.Message });
            return Ok(new { res.UserId });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var res = await _auth.LoginAsync(dto);
            if (!res.Success) return Unauthorized(new { res.Message });
            return Ok(new { token = res.Token });
        }
    }
}
