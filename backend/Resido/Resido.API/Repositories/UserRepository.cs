using Microsoft.EntityFrameworkCore;
using Resido.API.Models;
using Resido.API.Repositories.Interfaces;

namespace Resido.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ResidoDbContext _dbContext;
        public UserRepository(ResidoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
