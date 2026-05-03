
using Resido.API.Enums;

namespace Resido.API.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public int Floor { get; set; }
        public RoomStatus Status { get; set; } = RoomStatus.Available;
        public decimal RentPrice { get; set; }
        public decimal ElectricPrice { get; set; }
        public decimal WaterPrice { get; set; }
        public decimal ServiceFee { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = null;
        public DateTime? DeletedAt { get; set; } = null;
        public bool IsDeleted { get; set; } = false;


        // Navigation properties
        public Property Property { get; set; } = null!;
        public ICollection<RentalContract> RentalContract { get; set; } = new List<RentalContract>();
    }
}
