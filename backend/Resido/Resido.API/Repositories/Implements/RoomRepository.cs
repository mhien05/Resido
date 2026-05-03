using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteAsync(Room room)
        {
            room.IsDeleted = true;
            room.DeletedAt = DateTime.Now;

            _dbContext.Update(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(r => !r.IsDeleted) 
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
        }

        public async Task<IEnumerable<Room>> GetByPropertyIdAsync(Guid propertyId)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(r => r.PropertyId == propertyId && !r.IsDeleted)
                .OrderByDescending (r => r.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetByStatusAsync(RoomStatus status)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(r => r.Status == status && !r.IsDeleted)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        public async Task UpdateAsync(Room room)
        {
            room.UpdatedAt = DateTime.Now;

            _dbContext.Rooms.Update(room);
            await _dbContext.SaveChangesAsync();
            
        }
    }
}
