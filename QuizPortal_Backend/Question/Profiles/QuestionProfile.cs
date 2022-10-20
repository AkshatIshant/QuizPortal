using AutoMapper;
using QuestionMicroserviceAPI.Models.Domain;
using QuestionMicroserviceAPI.Models.Dto;

namespace QuestionMicroserviceAPI.Profiles
{
    public class QuestionProfile: Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionDto>().ReverseMap();
        }
    }
}
