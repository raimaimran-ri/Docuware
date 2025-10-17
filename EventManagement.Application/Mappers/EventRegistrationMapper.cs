using AutoMapper;
using EventManagement.Application.DTOs;
using EventManagement.Domain.Entities;

namespace EventManagement.Application.Mappers
{
    public class EventRegistrationMapper : Profile
    {
        public EventRegistrationMapper()
        {
            CreateMap<EventRegistration, EventRegistrationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.Event.name))
                .ForMember(dest => dest.EventDescription, opt => opt.MapFrom(src => src.Event.description))
                .ForMember(dest => dest.EventLocation, opt => opt.MapFrom(src => src.Event.location))
                .ForMember(dest => dest.EventStartTime, opt => opt.MapFrom(src => src.Event.start_time))
                .ForMember(dest => dest.EventEndTime, opt => opt.MapFrom(src => src.Event.end_time))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.name) ? src.name : src.User.name))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.email_address) ? src.email_address : src.User.email))
                .ForMember(dest => dest.UserPhoneNumber, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.phone_number) ? src.phone_number : src.User.phone_number))
                .ReverseMap();

            CreateMap<CreateEventRegistrationDTO, EventRegistration>()
                .ForMember(dest => dest.event_id, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.user_id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.email_address, opt => opt.MapFrom(src => src.UserEmail))
                .ForMember(dest => dest.phone_number, opt => opt.MapFrom(src => src.UserPhoneNumber))
                .ReverseMap();
        }
    }
}