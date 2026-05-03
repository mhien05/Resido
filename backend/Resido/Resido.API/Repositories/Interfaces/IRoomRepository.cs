

using Resido.API.Enums;
using Resido.API.Models;

namespace Resido.API.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        /// <summary>
        /// Lấy toàn bộ thông tin Rooms
        /// </summary>
        public Task<IEnumerable<Room>> GetAllAsync();
        /// <summary>
        /// Lấy thông tin room theo ID
        /// </summary>
        public Task<Room?> GetByIdAsync(Guid id);
        /// <summary>
        /// Thêm thông tin room
        /// </summary>
        public Task AddAsync(Room room);
        /// <summary>
        /// Cập nhật thông tin room
        /// </summary>
        public Task UpdateAsync(Room room);
        /// <summary>
        /// Xóa (soft delete) thông tin room
        /// </summary>
        public Task DeleteAsync(Room room);
        /// <summary>
        /// Lấy thông tin phòng theo Property ID
        /// </summary>
        public Task<IEnumerable<Room>> GetByPropertyIdAsync(Guid propertyId);
        /// <summary>
        /// Lấy thông tin phòng theo status
        /// </summary>
        public Task<IEnumerable<Room>> GetByStatusAsync(RoomStatus status);
    }
}
