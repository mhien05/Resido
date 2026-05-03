using Resido.API.Models;
using Resido.API.Repositories.Interfaces;

namespace Resido.API.Repositories.Implements
{
    public class PropertyRepository : IPropertyRepository
    {
        public Task AddAsync(Property property)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Property property)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Property?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
