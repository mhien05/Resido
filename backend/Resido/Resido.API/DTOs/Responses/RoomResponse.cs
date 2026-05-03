namespace Resido.API.DTOs.Responses
{
    public class RoomResponse
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public int Floor { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal RentPrice { get; set; }
        public decimal ElectricPrice { get; set; }
        public decimal WaterPrice { get; set; }
        public decimal ServiceFee { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
