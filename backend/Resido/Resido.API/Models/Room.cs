using System.Diagnostics.Contracts;

namespace Resido.API.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public int Floor { get; set; }
        public string Status { get; set; } = "Available";
        public decimal RentPrice { get; set; }
        public decimal ElectricPrice { get; set; }
        public decimal WaterPrice { get; set; }
        public decimal ServiceFee { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public Property Property { get; set; } = null!;
        public ICollection<RentalContract> RentalContract { get; set; } = new List<RentalContract>();
    }
}
