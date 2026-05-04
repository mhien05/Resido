using Resido.API.DTOs.Requests;
using Resido.API.DTOs.Responses;
using Resido.API.Repositories.Implements;

namespace Resido.API.Services.Interfaces
{
    public interface IRoomService
    {
        public Task<IEnumerable<RoomResponse>> GetAllAsync();
        public Task<RoomResponse?> GetByIdAsync(Guid id);
        public Task CreateAsync(RoomRequest request);
        public Task UpdateAsync(Guid id, RoomRequest request);
        public Task DeleteAsync(Guid id);

        public Task<IEnumerable<RoomResponse>> GetByPropertyIdAsync(Guid propertyId);
        public Task<IEnumerable<RoomResponse>> GetByStatusAsync(string status);
    }
}
