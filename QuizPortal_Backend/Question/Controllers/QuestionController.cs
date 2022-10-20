using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionMicroserviceAPI.Models.Domain;
using QuestionMicroserviceAPI.Models.Dto;
using QuestionMicroserviceAPI.Repositories;

namespace QuestionMicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IMapper mapper;

        public QuestionController(IQuestionRepository _questionRepository, IMapper? _mapper)
        {
            questionRepository = _questionRepository;
            mapper = _mapper;
         
        }
        

        [HttpGet]
        [Authorize(Roles ="Admin,Candidate")]
        public async Task<IActionResult> GetQuestionsAsync()
        {
            var allQues = await questionRepository.GetQuestionsAsync();
            if (allQues.Count == 0)
            {
                return NoContent();
            }

            var quesDto = mapper.Map<List<QuestionDto>>(allQues);
            return Ok(quesDto);
            

        }

        [HttpGet("Id")]
        [Authorize(Roles = "Admin,Candidate")]
        public async Task<IActionResult> GetQuestionByIdAsync(int id)
        {
            var ques = await questionRepository.GetQuestionByIdAsync(id);
            if (ques == null) 
            {
                return NotFound();
            }

            var quesDto = mapper.Map<QuestionDto>(ques);
            return Ok(quesDto);


        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddQuestionAsync(Question ques)
        {
            if (!ModelState.IsValid )
            {
                return BadRequest(ModelState);
            }

            if (ques == null) 
            {
                return NotFound();
            }
            else
            {
                var quesModel = new Question()
                {
                    QuestionText = ques.QuestionText,
                    Option1 = ques.Option1,
                    Option2 = ques.Option2,
                    Option3 = ques.Option3,
                    Option4 = ques.Option4,
                    CorrectAnswer = ques.CorrectAnswer,
                    DifficultyLevel = ques.DifficultyLevel,
                    QuestionGroupTitle = ques.QuestionGroupTitle,
                    TimeCreated = DateTime.Now,
                    TimeUpdated = DateTime.Now,
                };

                ques = await questionRepository.AddQuestionAsync(quesModel);
                var quesDto = mapper.Map<QuestionDto>(ques);
                return Ok(quesDto);

            }
        }

        [HttpDelete("Id")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteQuestionAsync(int id)
        {
            var ques = await questionRepository.DeleteQuestionAsync(id);
            if (ques == null) 
            {
                return BadRequest();
            }
             
            else
            {
                var quesDto = mapper.Map<QuestionDto>(ques);
                return Ok(true);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateQuestionASync(int id, Question question)
        {
            
            if (!ModelState.IsValid )
            {
                return BadRequest(ModelState);
            }

            var quest = await questionRepository.UpdateQuestionAsync(id, question);
            if (quest == null) 
            {
                return NoContent();
            }

            else
            { 

                var quesDto = mapper.Map<QuestionDto>(quest);
                return Ok(quesDto);

            }
        }

    }
}

