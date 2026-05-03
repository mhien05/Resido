using Resido.API.Models;

namespace Resido.API.Repositories.Interfaces
{
    public interface IPropertyRepository
    {
        /// <summary>
        /// Lấy toàn bộ thông tin Property
        /// </summary>
        /// <returns>
        /// IEnumerable với Property Object
        /// </returns>
        public Task<IEnumerable<Property>> GetAllAsync();
        /// <summary>
        /// Lấy thông tin Property bằng id
        /// </summary>
        public Task<Property?> GetByIdAsync(Guid id);
        /// <summary>
        /// Thêm property
        /// </summary>
        public Task AddAsync(Property property);
        /// <summary>
        /// Cập nhật thông tin Property
        /// </summary>
        public Task UpdateAsync(Property property);
        /// <summary>
        /// Xóa (soft delete) Property
        /// </summary>
        public Task DeleteAsync(Property property);

    }
}
