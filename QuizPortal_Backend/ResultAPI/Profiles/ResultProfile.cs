using AutoMapper;
using ResultMicroserviceAPI.Model.Domain;
using ResultMicroserviceAPI.Model.Dto;

namespace ResultMicroserviceAPI.Profiles
{
    public class ResultProfile :Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, ResultDto>().ReverseMap();
        }
    }
}
