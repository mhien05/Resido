using Microsoft.EntityFrameworkCore;
using Resido.API.Models;
using Resido.API.Repositories.Interfaces;

namespace Resido.API.Repositories.Implements
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ResidoDbContext _dbContext;

        public PropertyRepository(ResidoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Property property)
        {
            await _dbContext.AddAsync(property);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Property property)
        {
            property.IsDeleted = true;
            property.DeletedAt = DateTime.UtcNow;

            _dbContext.Properties.Update(property);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            return await _dbContext.Properties
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<Property?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Properties
                .AsNoTracking()
                .FirstOrDefaultAsync(x=>x.Id == id && !x.IsDeleted);
        }

        public async Task UpdateAsync(Property property)
        {
            property.UpdatedAt = DateTime.UtcNow;

            _dbContext.Properties.Update(property);
            await _dbContext.SaveChangesAsync();
        }
    }
}
