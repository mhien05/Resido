using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resido.API.DTOs.Requests;
using Resido.API.Models;
using Resido.API.Services.Interfaces;

namespace Resido.API.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]

    /// <summary>
    /// Controller xử lý các API liên quan đến xác thực người dùng
    /// </summary>
    public class AuthController : ControllerBase
    {
        // DI AuthService
        private readonly IAuthService _authService; // Service xử lý logic auth

        /// <summary>
        /// Constructor - ASP.NET tự inject IAuthService qua DI Container
        /// </summary>
        public AuthController(IAuthService authService)
        {
            _authService = authService; // Gắn vào field để dùng trong toàn controller
        }


        /// <summary>
        /// API login xử lý logic đăng nhập 
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request) // FromBody nhận dữ liệu trong request body
        {
            var response = await _authService.LoginAsync(request);

            if (response == null)
                return Unauthorized(new { message = "Username hoặc password không đúng" });

            return Ok(response);
        }
    }
}