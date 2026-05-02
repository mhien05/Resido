using Resido.API.Models;

namespace Resido.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetByUsernameAsync(string username);
    }
}
