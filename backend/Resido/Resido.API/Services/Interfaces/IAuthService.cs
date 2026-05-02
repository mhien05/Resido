using Resido.API.DTOs.Requests;
using Resido.API.DTOs.Responses;

namespace Resido.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request);
    }
}
