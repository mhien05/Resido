using Resido.API.DTOs.Requests;
using Resido.API.DTOs.Responses;

namespace Resido.API.Services.Interfaces
{
    public interface IPropertyService
    {
        public Task<IEnumerable<PropertyResponse>> GetAllAsync();
        public Task<PropertyResponse?> GetByIdAsync(Guid id);
        public Task CreateAsync(PropertyRequest request);
        public Task UpdateAsync(Guid id, PropertyRequest request);
        public Task DeleteAsync(Guid id);
    }
}
