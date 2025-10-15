using EventManagement.Domain.Entities;

namespace EventManagement.Infrastructure.Interfaces
{
    public interface IEventRegistrationRepository
    {
        Task<EventRegistration> GetByIdAsync(int id);
        Task<IEnumerable<EventRegistration>> GetAllAsync();
        Task AddAsync(EventRegistration eventRegistration);
        Task SaveChangesAsync();
    }
}