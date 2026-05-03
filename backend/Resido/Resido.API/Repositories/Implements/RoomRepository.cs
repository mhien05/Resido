using Resido.API.Enums;
using Resido.API.Models;
using Resido.API.Repositories.Interfaces;

namespace Resido.API.Repositories.Implements
{
    public class RoomRepository : IRoomRepository
    {
        public readonly ResidoDbContext _dbContext;
        public RoomRepository(ResidoDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Property property)
        {
            await _dbContext.AddAsync(property);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Property property)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetAllASync()
        {
            throw new NotImplementedException();
        }

        public Task<Property?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task GetByPropertyIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task GetByStatusAsync(RoomStatus status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
