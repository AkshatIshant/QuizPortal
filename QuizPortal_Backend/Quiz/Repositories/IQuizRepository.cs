

using QuizAPI.Models.Domain;

namespace QuizAPI.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetQuizesAsync();
        Task<Quiz> GetQuizByIdAsync(int id);
        Task<Quiz> AddQuizAsync(Quiz quiz);
        Task<Quiz> DeleteQuizAsync(int id);
        Task<Quiz> UpdateQuizAsync(int id, Quiz quiz);

    }
}
