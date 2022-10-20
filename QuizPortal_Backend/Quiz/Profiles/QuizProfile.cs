using AutoMapper;
using QuizAPI.Models.Domain;
using QuizAPI.Models.Dto;

namespace QuizMicroserviceAPI.Profiles
{
    public class QuizProfile:Profile
    {
        public QuizProfile()
        {
            CreateMap<Quiz, QuizDto>().ReverseMap();
        }
    }
}
