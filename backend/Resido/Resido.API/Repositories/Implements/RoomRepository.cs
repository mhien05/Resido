using Resido.API.Enums;
using Resido.API.Models;
using Resido.API.Repositories.Interfaces;

namespace Resido.API.Repositories.Implements
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ResidoDbContext _dbContext;
        public RoomRepository(ResidoDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Room room)
        {
            await _dbContext.AddAsync(room);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Room room)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Room?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetByPropertyIdAsync(Guid propertyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetByStatusAsync(RoomStatus status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
