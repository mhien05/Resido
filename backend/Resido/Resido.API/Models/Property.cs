namespace Resido.API.Models
{
    public class Property
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid OwnerId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public DateTime? UpdatedAt { get; set; } = null;

        // Navigation properties
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
