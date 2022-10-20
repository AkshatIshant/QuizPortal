using QuestionGroupMicroserviceAPI.Repositories.Interfaces;
using QuestionGroupMicroserviceAPI.Data;
using QuestionGroupMicroserviceAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace QuestionGroupMicroserviceAPI.Repositories
{
    public class QuestionGroupRepository: IQuestionGroupRepository
    {
        private readonly QuestionGroupDbContext questionGroupDbContext;
        public QuestionGroupRepository(QuestionGroupDbContext _questionGroupDbContext) 
        {
            questionGroupDbContext = _questionGroupDbContext;
        }
        public async Task<IEnumerable<QuestionGroup>> GetQuestionGroupsAsync()
        {
            return await questionGroupDbContext.QuestionGroups.ToListAsync();
        }
        public async Task<QuestionGroup> GetQuestionGroupByIdAsync(int id)
        {

            return await questionGroupDbContext.QuestionGroups.FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task<QuestionGroup> AddQuestionGroupAsync(QuestionGroup questionGroup)
        {
            await questionGroupDbContext.AddAsync(questionGroup);
            await questionGroupDbContext.SaveChangesAsync();
            return questionGroup;
        }
        public async Task<QuestionGroup> DeleteQuestionGroupAsync(int id)
        {
            var _questionGroup = await questionGroupDbContext.QuestionGroups.SingleAsync(x => x.Id == id);
            if (_questionGroup == null)
            {
                return null;
            }
            else
            {

                questionGroupDbContext.Remove(_questionGroup);
                await questionGroupDbContext.SaveChangesAsync();
            }

            return _questionGroup;
        }

        public async Task<QuestionGroup> UpdateQuestionGroupAsync(int id, QuestionGroup questionGroup)
        {
            var _questionGroups = await questionGroupDbContext.QuestionGroups.SingleAsync(x => x.Id == id);
            if (_questionGroups == null)
            {
                return null;
            }
            else
            {
                _questionGroups.Title = questionGroup.Title;

               // _questionGroups.TimeCreated = DateTime.Now;
                _questionGroups.TimeUpdated = DateTime.Now;
                _questionGroups.QuizTitle = questionGroup.QuizTitle;


                questionGroupDbContext.Update(_questionGroups);
                await questionGroupDbContext.SaveChangesAsync();
            }

            return questionGroup;
        }
    }
}
