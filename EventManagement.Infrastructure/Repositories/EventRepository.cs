using EventManagement.Domain.Entities;
using EventManagement.Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly PostgresContext _context;
        public EventRepository(PostgresContext context)
        {
            _context = context;
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _context.Events
                .Include(e => e.User)
                .Include(e => e.EventRegistrations)
                .FirstOrDefaultAsync(e => e.id == id);
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _context.Events
                .Include(e => e.User)
                .Include(e => e.EventRegistrations)
                .ToListAsync();
        }

        public async Task AddAsync(Event evnt)
        {
            await _context.Events.AddAsync(evnt);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
