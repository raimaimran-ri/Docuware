namespace EventManagement.Application.Services
{
    using AutoMapper;
    using EventManagement.Application.DTOs;
    using EventManagement.Application.Interfaces;
    using EventManagement.Domain.Entities;
    using EventManagement.Infrastructure.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class EventRegistrationService : IEventRegistrationService
    {
        private readonly IEventRegistrationRepository _eventRegistrationRepositoryService;
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<EventRegistrationService> _logger;
        private readonly IMapper _mapper;

        public EventRegistrationService(IEventRegistrationRepository eventRegistrationRepositoryService, IEventRepository eventRepository, IUserRepository userRepository, ILogger<EventRegistrationService> logger, IMapper mapper)
        {
            _eventRegistrationRepositoryService = eventRegistrationRepositoryService;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> CreateEventRegistrationAsync(CreateEventRegistrationDTO dto)
        {
            try
            {
                var eventEntity = await _eventRepository.GetByIdAsync(dto.EventId);
                if (eventEntity == null)
                {
                    throw new Exception("Event not found");
                }

                var registration = _mapper.Map<EventRegistration>(dto);
                await _eventRegistrationRepositoryService.AddAsync(registration);
                await _eventRegistrationRepositoryService.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("EventRegistrationService: Error creating event registration", ex.Message);
                throw new Exception("Failed to create event registration");
            }

        }

        public async Task<List<EventRegistrationDTO>> GetAllEventRegistrationsAsync()
        {
            try
            {
                var registrations = await _eventRegistrationRepositoryService.GetAllAsync();
                return _mapper.Map<List<EventRegistrationDTO>>(registrations);
            }
            catch (Exception ex)
            {
                _logger.LogError("EventRegistrationService: Error retrieving event registrations", ex.Message);
                throw new Exception("Failed to retrieve event registrations");
            }
        }

        public async Task<List<EventRegistrationDTO>> GetEventRegistrationsByEventIdAsync(int eventId)
        {
            try
            {
                //use context to get user 
                var registrations = await _eventRegistrationRepositoryService.GetByEventIdAsync(eventId);
                return _mapper.Map<List<EventRegistrationDTO>>(registrations.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError("EventRegistrationService: Error retrieving event registrations by event ID", ex.Message);
                throw new Exception("Failed to retrieve event registrations by event ID");
            }
        }
    }
}