using Resido.API.DTOs.Requests;
using Resido.API.DTOs.Responses;
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

        public Task CreateAsync(PropertyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PropertyResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PropertyResponse?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, PropertyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
