using QuestionMicroserviceAPI.Models.Domain;

namespace QuestionMicroserviceAPI.Repositories
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetQuestionsAsync();
        Task<Question> GetQuestionByIdAsync(int id);
        Task<Question> AddQuestionAsync(Question question);
        Task<Question> DeleteQuestionAsync(int id);
        Task<Question> UpdateQuestionAsync(int id, Question question);
    }
}
