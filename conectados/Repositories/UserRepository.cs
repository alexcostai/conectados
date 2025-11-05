using conectados.Data;
using conectados.Models;
using Microsoft.EntityFrameworkCore;

namespace conectados.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConectadosDBContext _context;

        public UserRepository(ConectadosDBContext context)
        {
            this._context = context;
        }
        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
