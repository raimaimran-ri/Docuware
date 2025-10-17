using EventManagement.Application.DTOs;
namespace EventManagement.Application.Interfaces
{
    public interface IEventRegistrationService
    {
        Task<bool> CreateEventRegistrationAsync(CreateEventRegistrationDTO dto);
        Task<List<EventRegistrationDTO>> GetAllEventRegistrationsAsync();
        Task<List<EventRegistrationDTO>> GetEventRegistrationsByEventIdAsync(int eventId);
    }
}
