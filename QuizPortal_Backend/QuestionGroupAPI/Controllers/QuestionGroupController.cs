using AutoMapper;
using QuestionGroupMicroserviceAPI.Models.Dto;
using QuestionGroupMicroserviceAPI.Repositories;
using QuestionGroupMicroserviceAPI.Repositories.Interfaces;
using QuestionGroupMicroserviceAPI.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuestionGroupMicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class QuestionGroupController : ControllerBase
    {
        private readonly IQuestionGroupRepository questionGroupRepository;
        private readonly IMapper mapper;
        public QuestionGroupController(IQuestionGroupRepository _questionGroupRepository, IMapper _mapper)
        {
            questionGroupRepository = _questionGroupRepository;
            mapper = _mapper;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Candidate")]
        public async Task<IActionResult> GetQuestionGroupsAsync()
        {
            var quesGrp = await questionGroupRepository.GetQuestionGroupsAsync();

            if (quesGrp== null)
            {
                return NoContent();
            }
            var quesGrpDto = mapper.Map<List<QuestionGroupDto>>(quesGrp);
            return Ok(quesGrpDto);

        }

        [HttpGet("Id")]
        [Authorize(Roles = "Admin,Candidate")]

        public async Task<IActionResult> GetQuestionGroupByIdAsync(int id)
        {
            var quesGrp = await questionGroupRepository.GetQuestionGroupByIdAsync(id);
            if (quesGrp == null)
            {
                return NotFound();
            }
            var quesGrpDto = mapper.Map<QuestionGroupDto>(quesGrp);
            return Ok(quesGrpDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddQuestionGroupAsync(QuestionGroup quesGrp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (quesGrp == null)
            {
                return NotFound();
            }
            else
            {
                var quesGroup = new QuestionGroup()
                {
                    
                    Title = quesGrp.Title,
                    TimeCreated = DateTime.Now,
                    TimeUpdated = DateTime.Now,
                    QuizTitle = quesGrp.QuizTitle,
                   
                      
                };

                quesGrp = await questionGroupRepository.AddQuestionGroupAsync(quesGroup);
                
                    var quesGrpDto = mapper.Map<QuestionGroupDto>(quesGrp);
                    return Ok(quesGrpDto);
                
            }

        }
        [HttpDelete("Id")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteQuestionGroupAsync(int id)
        {
            var quesGrp = await questionGroupRepository.DeleteQuestionGroupAsync(id);
            if (quesGrp == null)
                return BadRequest();
            else
            {
                var quesGrpDto = mapper.Map<QuestionGroupDto>(quesGrp);
                return Ok(quesGrpDto);
            }
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateQuestionGroupASync(int id, QuestionGroup questionGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var quesGrp = await questionGroupRepository.UpdateQuestionGroupAsync(id, questionGroup);
                if (quesGrp == null)
                {
                    return NoContent();
                }
                else
                {
                    var quesGrpDto = mapper.Map<QuestionGroupDto>(quesGrp);
                    return Ok(quesGrpDto);
                }
            }
        }

    }
}




    
    
