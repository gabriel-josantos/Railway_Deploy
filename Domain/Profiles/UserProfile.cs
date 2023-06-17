using AutoMapper;
using DesafioMxM.Domain.Dtos;
using DesafioMxM.Domain.Models;

namespace DesafioMxM.Domain.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<SignupDto, User>();
        CreateMap<SignupDto, Address>();
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.Neighborhood, opt => opt.MapFrom(src => src.Address.Neighborhood))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.AddressNumber, opt => opt.MapFrom(src => src.Address.AddressNumber))
            .ForMember(dest => dest.Complement, opt => opt.MapFrom(src => src.Address.Complement));



    }

}

