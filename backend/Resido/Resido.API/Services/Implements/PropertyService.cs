using Microsoft.VisualBasic;
using Resido.API.DTOs.Requests;
using Resido.API.DTOs.Responses;
using Resido.API.Models;
using Resido.API.Repositories.Interfaces;
using Resido.API.Services.Interfaces;

namespace Resido.API.Services.Implements
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task CreateAsync(PropertyRequest request)
        {
            // Tạo entity mới từ Request
            var property = new Property
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Address = request.Address,
                Description = request.Description
            };

            await _propertyRepository.AddAsync(property);
        }

        public async Task DeleteAsync(Guid id)
        {
            // Gọi method GetById ở repository
            var property = await _propertyRepository.GetByIdAsync(id);

            // Kiểm tra null
            if(property == null)
                throw new KeyNotFoundException($"Property với ID {id} không tồn tại");

            // Gọi method Delete ở repository
            await _propertyRepository.DeleteAsync(property);
        }

        public async Task<IEnumerable<PropertyResponse>> GetAllAsync()
        {
            // Gọi repository để lấy danh sách Entity
            var properties = await _propertyRepository.GetAllAsync();

            // Map từ property (Entity) -> PropertyResponse (DTO)
            var response = properties.Select(p => new PropertyResponse
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address,
                Description = p.Description,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            });

            return response;
        }


        public async Task<PropertyResponse?> GetByIdAsync(Guid id)
        {
            // Gọi repository
            var property = await _propertyRepository.GetByIdAsync(id);

            // Nếu không tìm thấy return null
            if(property == null) return null;

            // Map Entity -> Response
            var response = new PropertyResponse
            {
                Id = property.Id,
                Name = property.Name,
                Address = property.Address,
                Description = property.Description,
                IsActive = property.IsActive,
                CreatedAt = property.CreatedAt,
                UpdatedAt = property.UpdatedAt
            };

            // Return
            return response;
        }

        public async Task UpdateAsync(Guid id, PropertyRequest request)
        {
            // Gọi method GetById ở repository
            var property = await _propertyRepository.GetByIdAsync(id);

            // Kiểm tra entity có tồn tại không 
            if(property == null)
                throw new KeyNotFoundException($"Property với ID {id} không tồn tại");

            // Cập nhật các field từ request
            property.Name = request.Name;
            property.Address = request.Address;
            property.Description = request.Description;

            // Gọi method Update ở repository
            await _propertyRepository.UpdateAsync(property);
        }
    }
}
