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
            // Set thời gian tạo 
            property.CreatedAt = DateTime.UtcNow;

            await _dbContext.AddAsync(property);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Property property)
        {
            // Set trường đã bị xóa chưa = true
            property.IsDeleted = true;

            // Set thời gian xóa
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
            // Set thời gian update thông tin
            property.UpdatedAt = DateTime.UtcNow;

            _dbContext.Properties.Update(property);
            await _dbContext.SaveChangesAsync();
        }
    }
}
