using EventManagement.Domain.Entities;
using EventManagement.Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgresContext _context;
        public UserRepository(PostgresContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.EventRegistrations)
                .Include(u => u.User_role)
                .FirstOrDefaultAsync(u => u.email == email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.EventRegistrations)
                .Include(u => u.User_role)
                .FirstOrDefaultAsync(u => u.id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> VerifyCredentialsAsync(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.email == email && u.password_hash == password);
            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}

