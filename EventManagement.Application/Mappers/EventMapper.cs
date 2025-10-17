using AutoMapper;
using EventManagement.Application.DTOs;
using EventManagement.Domain.Entities;

namespace EventManagement.Application.Mappers
{
    public class EventMapper : Profile
    {
        public EventMapper()
        {
            CreateMap<Event, EventDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.location))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.start_time))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.end_time))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.created_on))
                .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src => src.User.name))
                .ReverseMap();
                
            CreateMap<CreateEventDTO, Event>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.start_time, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.end_time, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.created_on, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ReverseMap();
        }
    }
}