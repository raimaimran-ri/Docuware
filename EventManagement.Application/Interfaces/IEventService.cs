using EventManagement.Application.DTOs;

namespace EventManagement.Application.Interfaces
{
    public interface IEventService
    {
        Task<bool> CreateEventAsync(CreateEventDTO dto);
        Task<List<EventDTO>> GetAllEventsAsync();
    }
}