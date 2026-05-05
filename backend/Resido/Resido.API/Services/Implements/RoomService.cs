using Resido.API.DTOs.Requests;
using Resido.API.DTOs.Responses;
using Resido.API.Enums;
using Resido.API.Models;
using Resido.API.Repositories.Interfaces;
using Resido.API.Services.Interfaces;

namespace Resido.API.Services.Implements
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IPropertyRepository _propertyRepository;

        public RoomService(IRoomRepository roomRepository, IPropertyRepository propertyRepository)
        {
            _roomRepository = roomRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task CreateAsync(RoomRequest request)
        {
            // ✅ Thêm await
            var property = await _propertyRepository.GetByIdAsync(request.PropertyId);

            if (property == null)
                throw new KeyNotFoundException($"Property với ID {request.PropertyId} không tồn tại");

            // Thêm validation: Property phải active mới tạo room được
            if (!property.IsActive)
                throw new InvalidOperationException($"Không thể tạo phòng cho Property không hoạt động");

            var room = new Room
            {
                Id = Guid.NewGuid(),
                PropertyId = request.PropertyId,
                Code = request.Code,
                Floor = request.Floor,
                Status = request.Status,
                RentPrice = request.RentPrice,
                ElectricPrice = request.ElectricPrice,
                WaterPrice = request.WaterPrice,
                ServiceFee = request.ServiceFee
            };

            // Save vào database
            await _roomRepository.AddAsync(room);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoomResponse?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomResponse>> GetByPropertyIdAsync(Guid propertyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomResponse>> GetByStatusAsync(RoomStatus status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, RoomRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
