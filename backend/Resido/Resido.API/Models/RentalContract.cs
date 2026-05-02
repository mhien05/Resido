namespace Resido.API.Models
{
    public class RentalContract
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }

        // Navigation
        public Room Room { get; set; } = null!;
    }
}