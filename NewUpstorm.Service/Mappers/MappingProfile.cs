using AutoMapper;
using NewUpstorm.Domain.Entities;
using NewUpstorm.Service.DTOs;

namespace NewUpstorm.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserCreationDto>().ReverseMap();
            CreateMap<User, UserForResultDto>().ReverseMap();
            CreateMap<User, UserForUpdateDto>().ReverseMap();
        }
    }
}
