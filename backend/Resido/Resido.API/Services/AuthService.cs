using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Resido.API.DTOs.Requests;
using Resido.API.DTOs.Responses;
using Resido.API.Models;
using Resido.API.Repositories.Interfaces;
using Resido.API.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Resido.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            // 1. Tìm user theo username
            var user = await _userRepository.GetByUsernameAsync(request.Username);

            if (user == null) return null;

            // 2. Verify password
            bool isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isValid) return null;

            // 3. Tạo JWT token
            var token = GenerateToken(user);

            return new LoginResponse
            {
                AccessToken = token.Token,
                FullName = user.FullName,
                Role = user.Role,
                ExpiresAt = token.ExpiresAt
            };
        }

        private (string Token, DateTime ExpiresAt) GenerateToken(Models.User user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiresInMinutes = int.Parse(_config["Jwt:ExpiresInMinutes"]!);
            var expiresAt = DateTime.UtcNow.AddMinutes(expiresInMinutes);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expiresAt,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
        }

    }
}
