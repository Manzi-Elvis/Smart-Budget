using SmartBudget.Application.DTOs;
using SmartBudget.Core.Entities;
using SmartBudget.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartBudget.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _users;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository users, IConfiguration config)
        {
            _users = users;
            _config = config;
        }

        public async Task<(bool Success, string Message, Guid? UserId)> RegisterAsync(RegisterDto dto)
        {
            // basic validation
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                return (false, "Email and password are required.", null);

            var exists = await _users.GetByEmailAsync(dto.Email);
            if (exists != null) return (false, "Email already taken.", null);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password) // simple hashing
            };

            await _users.AddAsync(user);
            return (true, "Registered", user.Id);
        }

        public async Task<(bool Success, string Message, string? Token)> LoginAsync(LoginDto dto)
        {
            var user = await _users.GetByEmailAsync(dto.Email);
            if (user == null) return (false, "Invalid credentials.", null);

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return (false, "Invalid credentials.", null);

            // generate token
            var key = _config["Jwt:Key"] ?? "ThisIsADevSecretKeyChangeMe";
            var issuer = _config["Jwt:Issuer"] ?? "SmartBudget";
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (true, "OK", tokenHandler.WriteToken(token));
        }
    }
}
