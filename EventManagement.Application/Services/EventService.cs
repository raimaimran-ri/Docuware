using AutoMapper;
using EventManagement.Application.DTOs;
using EventManagement.Application.Interfaces;
using EventManagement.Domain.Entities;
using EventManagement.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace EventManagement.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EventService> _logger;
        public EventService(IEventRepository eventRepository, IUserRepository userRepository, IMapper mapper, ILogger<EventService> logger)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> CreateEventAsync(CreateEventDTO dto)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(dto.UserId);

                if (user.User_role.name == "EventCreator")
                {
                    throw new UnauthorizedAccessException("Event Service: User does not have permission to create events.");
                }

                var evt = _mapper.Map<Event>(dto);
                await _eventRepository.AddAsync(evt);
                await _eventRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("EventService: Error creating event", ex.Message);
                throw new Exception("Failed to create event");
            }
        }

        public async Task<List<EventDTO>> GetAllEventsAsync()
        {
            try
            {
                var events =  await _eventRepository.GetAllAsync();
                return _mapper.Map<List<EventDTO>>(events);
            }
            catch (Exception ex)
            {
                _logger.LogError("EventService: Error retrieving events", ex.Message);
                throw new Exception("Failed to retrieve events");
            }

        }
    }
}