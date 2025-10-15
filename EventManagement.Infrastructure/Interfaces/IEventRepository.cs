using EventManagement.Domain.Entities;

namespace EventManagement.Infrastructure.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> GetByIdAsync(int id);
        Task<IEnumerable<Event>> GetAllAsync();
        Task AddAsync(Event evnt);
        Task SaveChangesAsync();
    }
}