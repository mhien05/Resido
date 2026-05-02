using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resido.API.DTOs.Requests;
using Resido.API.Models;
using Resido.API.Services.Interfaces;

namespace Resido.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authService.LoginAsync(request);

            if (response == null)
                return Unauthorized(new { message = "Username hoặc password không đúng" });

            return Ok(response);
        }
    }
}