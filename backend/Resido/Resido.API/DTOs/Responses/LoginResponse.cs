namespace Resido.API.DTOs.Responses
{
    public class LoginResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}
