using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ResultMicroserviceAPI.Model.Domain;
using ResultMicroserviceAPI.Model.Dto;
using ResultMicroserviceAPI.Repository.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace ResultMicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepository resultRepository;
        private readonly IMapper mapper;
        public ResultController(IResultRepository _resultRepository, IMapper _mapper)
        {
            resultRepository = _resultRepository;
            mapper = _mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Candidate")]
        public async Task<IActionResult> GetAllResAsync()
        {
            var allres = await resultRepository.GetAllResultsAsync();

            if (allres.Count() == 0)
            {
                return NoContent();
            }
            var resDto = mapper.Map<List<ResultDto>>(allres);
            return Ok(resDto);
        }

        [HttpGet("Id")]
        [Authorize(Roles = "Admin,Candidate")]
        public async Task<IActionResult> GetResultByIdAsync(int id)
        {
            var res = await resultRepository.GetResultByIdAsync(id);
            if (res == null)
            {
                return NoContent();
            }
            var resById = await resultRepository.GetResultByIdAsync(id);
            var resDto = mapper.Map<ResultDto>(resById);
            return Ok(resDto);

        }

        [HttpGet("username")]
        [Authorize(Roles = "Admin,Candidate")]
        public async Task<IActionResult> GetResultByNameAsync(string username)
        {
            var result = await resultRepository.GetResultByNameAsync(username);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> AddAsync(Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var resultmodel = new Result()
                {

                    Id = result.Id,
                    MarksObtained = result.MarksObtained,
                    ExamDate = result.ExamDate,
                    QuizTitle = result.QuizTitle,
                    UserName = result.UserName,
                };

                var res= await resultRepository.AddResultAsync(result);
                var resultDto = mapper.Map<ResultDto>(res);
                return Created("Succesfully created",resultDto);
            }
        }
    }

}