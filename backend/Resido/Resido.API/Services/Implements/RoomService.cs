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

        public Task CreateAsync(RoomRequest request)
        {
            // Kiểm tra property với id từ request
            var property = _propertyRepository.GetByIdAsync(request.PropertyId);

            // Check property có null không
            if(property == null)
                throw new KeyNotFoundException($"Property với ID {request.PropertyId} không tồn tại");

            // Mapping thông tin từ request -> entity
            var room = new Room
            {
                PropertyId = request.PropertyId,
                Code = request.Code,
                Status = request.Status,
                RentPrice = request.RentPrice,
                ElectricPrice = request.ElectricPrice,
                WaterPrice = request.WaterPrice,
                ServiceFee = request.ServiceFee   
            };
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
