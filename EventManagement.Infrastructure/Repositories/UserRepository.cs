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

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.EventRegistrations)
                .FirstOrDefaultAsync(u => u.id == id);
        }
    }
}

