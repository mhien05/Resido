using Resido.API.Enums;

namespace Resido.API.DTOs.Requests
{
    public class RoomRequest
    {
        public Guid PropertyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public int Floor { get; set; }
        public RoomStatus Status { get; set; } = RoomStatus.Available;
        public decimal RentPrice { get; set; }
        public decimal ElectricPrice { get; set; }
        public decimal WaterPrice { get; set; }
        public decimal ServiceFee { get; set; }
    }
}
