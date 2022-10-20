using Microsoft.EntityFrameworkCore;
using QuestionMicroserviceAPI.Data;
using QuestionMicroserviceAPI.Models.Domain;

namespace QuestionMicroserviceAPI.Repositories
{
    public class QuestionRepository:IQuestionRepository
    {
        private readonly QuestionDbContext questionDbContext;

        public QuestionRepository(QuestionDbContext _questionDbContext)
        {
            questionDbContext = _questionDbContext;
        }

        public async Task<List<Question>> GetQuestionsAsync()
        {
            return await questionDbContext.Questions.ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            var ques = await questionDbContext.Questions.FirstOrDefaultAsync(x => x.Id == id);
            return ques;
        }

        public async Task<Question> AddQuestionAsync(Question question)
        {
            await questionDbContext.AddAsync(question);
            await questionDbContext.SaveChangesAsync();
            return question;
        }

        public async Task<Question> DeleteQuestionAsync(int id)
        {
            var ques = await questionDbContext.Questions.FirstOrDefaultAsync(x => x.Id == id);
            questionDbContext.Questions.Remove(ques);
            await questionDbContext.SaveChangesAsync();
            
            return ques;
        }

        public async Task<Question> UpdateQuestionAsync(int id, Question question)
        {
            var ques = await questionDbContext.Questions.Where(x => x.Id == id).SingleAsync();

            ques.QuestionText = question.QuestionText;
            ques.Option1 = question.Option1;
            ques.Option2 = question.Option2;
            ques.Option3 = question.Option3;
            ques.Option4 = question.Option4;
            ques.CorrectAnswer = question.CorrectAnswer;
            ques.DifficultyLevel = question.DifficultyLevel;
            ques.QuestionGroupTitle=question.QuestionGroupTitle;  
            ques.TimeUpdated = DateTime.Now;

            questionDbContext.Questions.Update(ques);
            await questionDbContext.SaveChangesAsync();

            return ques;
        }
    }
}

