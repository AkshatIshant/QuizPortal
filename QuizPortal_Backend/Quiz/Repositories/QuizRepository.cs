using QuizAPI.Repositories.Interfaces;
using QuizAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;

namespace QuizAPI.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        
        private readonly QuizPortalDbContext quizAPIDbContext;
        public QuizRepository(QuizPortalDbContext _quizAPIDbContext)
        {
            quizAPIDbContext = _quizAPIDbContext;
        }

        public async Task<IEnumerable<Quiz>> GetQuizesAsync()
        {
            return await quizAPIDbContext.Quizs.ToListAsync();
        }
        public async Task<Quiz> GetQuizByIdAsync(int id)
        {
            return await quizAPIDbContext.Quizs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Quiz> AddQuizAsync(Quiz quiz)
        {
            await quizAPIDbContext.Quizs.AddAsync(quiz);
            await quizAPIDbContext.SaveChangesAsync();
            return quiz;
        }

        public async Task<Quiz> DeleteQuizAsync(int id)
        {
            var _quiz = await quizAPIDbContext.Quizs.FirstOrDefaultAsync(x => x.Id == id);
            if (_quiz == null)
            {
                return null;
            }
            else
            {
                quizAPIDbContext.Quizs.Remove(_quiz);
                await quizAPIDbContext.SaveChangesAsync();
            }
            return _quiz;
        }

        public async Task<Quiz> UpdateQuizAsync(int id, Quiz quiz)
        {
            var _quiz = await quizAPIDbContext.Quizs.SingleAsync(x => x.Id == id);
            if (_quiz == null)
            {
                return null;
            }
            else
            {
                _quiz.QuizTitle = quiz.QuizTitle;
                _quiz.Description = quiz.Description;
                _quiz.StartTime = quiz.StartTime;
                _quiz.EndTime = quiz.EndTime;   


                quizAPIDbContext.Update(_quiz);
                await quizAPIDbContext.SaveChangesAsync();
            }

            return _quiz;
        }
    }

  
}
