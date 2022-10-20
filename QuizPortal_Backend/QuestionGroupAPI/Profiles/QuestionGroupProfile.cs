using AutoMapper;
using QuestionGroupMicroserviceAPI.Models.Domain;
using QuestionGroupMicroserviceAPI.Models.Dto;

namespace QuestionGroupMicroserviceAPI.Profiles
{
    public class QuestionGroupProfile:Profile
    {
        public QuestionGroupProfile()
        {
            CreateMap<QuestionGroup, QuestionGroupDto>().ReverseMap();
        }
    }
}
