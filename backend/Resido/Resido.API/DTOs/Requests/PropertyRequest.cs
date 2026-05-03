namespace Resido.API.DTOs.Requests
{
    public class PropertyRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
    }
}
