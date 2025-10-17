using AutoMapper;
using EventManagement.Application.DTOs;
using EventManagement.Domain.Entities;

namespace EventManagement.Application.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.phone_number))
                .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.User_role.name))
                .ReverseMap();

            CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.password_hash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.phone_number, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.user_role_id, opt => opt.MapFrom(src => src.UserRoleId))
                .ReverseMap();
        }
    }
}