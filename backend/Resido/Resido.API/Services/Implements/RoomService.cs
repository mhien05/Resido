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
            // Kiểm tra entity Property với {id} có tồn tại không
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

        public async Task DeleteAsync(Guid id)
        {
            var room = await _roomRepository.GetByIdAsync(id);

            if (room == null)
                throw new KeyNotFoundException($"Phòng với ID {id} không tồn tại");

            if (room.Status == RoomStatus.Occupied)
                throw new InvalidOperationException("Không thể xóa phòng đang có người thuê");

            await _roomRepository.DeleteAsync(room);
        }

        public async Task<IEnumerable<RoomResponse>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();

            var response = rooms.Select(r => new RoomResponse
            {
                Id = r.Id,
                PropertyId = r.PropertyId,
                Code = r.Code,
                Floor = r.Floor,
                Status = r.Status.ToString(),
                RentPrice = r.RentPrice,
                ElectricPrice = r.ElectricPrice,
                WaterPrice = r.WaterPrice,
                ServiceFee = r.ServiceFee,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt,
            });

            return response;
        }

        public async Task<RoomResponse?> GetByIdAsync(Guid id)
        {
            var room = await _roomRepository.GetByIdAsync(id);

            if (room == null)
                throw new KeyNotFoundException($"Phòng với ID {id} không tồn tại");

            var response = new RoomResponse
            {
                Id = room.Id,
                PropertyId = room.PropertyId,
                Code = room.Code,
                Floor = room.Floor,
                Status = room.Status.ToString(),
                RentPrice = room.RentPrice,
                ElectricPrice = room.ElectricPrice,
                WaterPrice = room.WaterPrice,
                ServiceFee = room.ServiceFee,
                CreatedAt = room.CreatedAt,
                UpdatedAt = room.UpdatedAt,
            };

            return response;
        }

        public async Task<IEnumerable<RoomResponse>> GetByPropertyIdAsync(Guid propertyId)
        {
            var room = await _roomRepository.GetByPropertyIdAsync(propertyId);

            if(!room.Any())
                throw new KeyNotFoundException($"Phòng với PropertyID {propertyId} không tồn tại");

            var response = room.Select(r => new RoomResponse
            {
                Id = r.Id,
                PropertyId = r.PropertyId,
                Code = r.Code,
                Floor = r.Floor,
                Status = r.Status.ToString(),
                RentPrice = r.RentPrice,
                ElectricPrice = r.ElectricPrice,
                WaterPrice = r.WaterPrice,
                ServiceFee = r.ServiceFee,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt
            });

            return response;
        }

        public async Task<IEnumerable<RoomResponse>> GetByStatusAsync(RoomStatus status)
        {
            var room = await _roomRepository.GetByStatusAsync(status);

            if (!room.Any())
                throw new KeyNotFoundException($"Các phòng với status {status}  không tồn tại");

            var response = room.Select(r => new RoomResponse
            {
                Id = r.Id,
                PropertyId = r.PropertyId,
                Code = r.Code,
                Floor = r.Floor,
                Status = r.Status.ToString(),
                RentPrice = r.RentPrice,
                ElectricPrice = r.ElectricPrice,
                WaterPrice = r.WaterPrice,
                ServiceFee = r.ServiceFee,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt
            });

            return response;
        }

        public async Task UpdateAsync(Guid id, RoomRequest request)
        {
            // Tìm phòng với ID
            var room = await _roomRepository.GetByIdAsync(id);

            // Nếu không tìm thấy thì throw excep
            if (room == null)
                throw new KeyNotFoundException($"Phòng với ID {id} không tồn tại");

            // Map các field từ request
            room.PropertyId = request.PropertyId;
            room.Code = request.Code;
            room.Floor = request.Floor;
            room.Status = request.Status;
            room.RentPrice = request.RentPrice;
            room.ElectricPrice = request.ElectricPrice;
            room.WaterPrice = request.WaterPrice;
            room.ServiceFee = request.ServiceFee;

            // Update giá trị mới
            await _roomRepository.UpdateAsync(room);
        }
    }
}
