using AutoMapper;
using UserMicroserviceAPI.Models.Dto;
using UserMicroserviceAPI.Models.Domain;

namespace UserMicroserviceAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
