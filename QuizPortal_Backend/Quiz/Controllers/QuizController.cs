using AutoMapper;
using QuizAPI.Models.Dto;
using QuizAPI.Repositories.Interfaces;
using QuizAPI.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository quizRepository;
        private readonly IMapper mapper;
        public QuizController(IQuizRepository _quizRepository, IMapper _mapper)
        {
            quizRepository = _quizRepository;
            mapper = _mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Candidate")]

        public async Task<IActionResult> GetQuizesAsync()
        {
            var allQuizs = await quizRepository.GetQuizesAsync();
            
            if (allQuizs == null)
            { return NoContent(); }
            var quizsDto = mapper.Map<List<QuizDto>>(allQuizs);
            return Ok(quizsDto);
        }

        [HttpGet("Id")]
        [Authorize(Roles = "Admin,Candidate")]
        public async Task<IActionResult> GetQuizByIdAsync(int id)
        {
            var quizs = await quizRepository.GetQuizByIdAsync(id);
            if (quizs == null)
            { return NoContent(); }

            var quizsDto = mapper.Map<QuizDto>(quizs);
            return Ok(quizsDto);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddQuizAsync(Quiz quizs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var quizsModel = new Quiz()
                {
                    QuizTitle = quizs.QuizTitle,
                    Description = quizs.Description,
                    StartTime = quizs.StartTime,
                    EndTime = quizs.EndTime,

                };

                quizs = await quizRepository.AddQuizAsync(quizsModel);
                var quizsDto = mapper.Map<QuizDto>(quizs);
                return Ok(quizsDto);

            }
        }

        [HttpDelete("Id")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteQuizAsync(int id)
        {
            var quizs = await quizRepository.DeleteQuizAsync(id);
            if (quizs == null)
                return BadRequest();
            else
            {
                var quizsDto = mapper.Map<QuizDto>(quizs);
                return Ok(quizsDto);
            }
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateQuizAsync(int id, Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var ques = await quizRepository.UpdateQuizAsync(id, quiz);
                if (quiz == null)
                {
                    return NoContent();
                }
                else
                {
                    var quesDto = mapper.Map<QuizDto>(ques);
                    return Ok(quesDto);
                }
            }
        }
    }
}
