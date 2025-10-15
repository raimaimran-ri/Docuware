using EventManagement.Domain.Entities;
using EventManagement.Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Infrastructure.Repositories
{
    public class EventRegistrationRepository : IEventRegistrationRepository
    {
        private readonly PostgresContext _context;
        public EventRegistrationRepository(PostgresContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EventRegistration eventRegistration)
        {
            await _context.EventRegistrations.AddAsync(eventRegistration);
        }

        public async Task<IEnumerable<EventRegistration>> GetAllAsync()
        {
            return await _context.EventRegistrations
                .Include(er => er.Event)
                .Include(er => er.User)
                .ToListAsync();
        }

        public async Task<EventRegistration> GetByIdAsync(int id)
        {
            return await _context.EventRegistrations
                .Include(er => er.Event)
                .Include(er => er.User)
                .FirstOrDefaultAsync(er => er.id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
