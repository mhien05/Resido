

using Resido.API.Enums;
using Resido.API.Models;

namespace Resido.API.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        /// <summary>
        /// Lấy toàn bộ thông tin Rooms
        /// </summary>
        public Task<IEnumerable<Property>> GetAllASync();
        /// <summary>
        /// Lấy thông tin room theo ID
        /// </summary>
        public Task<Property?> GetByIdAsync(Guid id);
        /// <summary>
        /// Thêm thông tin room
        /// </summary>
        public Task AddAsync(Property property);
        /// <summary>
        /// Cập nhật thông tin room
        /// </summary>
        public Task UpdateAsync(Property property);
        /// <summary>
        /// Xóa (soft delete) thông tin room
        /// </summary>
        public Task DeleteAsync(Property property);
        /// <summary>
        /// Lấy thông tin phòng theo Property ID
        /// </summary>
        public Task GetByPropertyIdAsync(Guid id);
        /// <summary>
        /// Lấy thông tin phòng theo status
        /// </summary>
        public Task GetByStatusAsync(RoomStatus status);
    }
}
