using QuestionGroupMicroserviceAPI.Models.Domain;

namespace QuestionGroupMicroserviceAPI.Repositories.Interfaces
{
    public interface IQuestionGroupRepository
    {
        Task<IEnumerable<QuestionGroup>> GetQuestionGroupsAsync();
        Task<QuestionGroup> GetQuestionGroupByIdAsync(int id);
        Task<QuestionGroup> AddQuestionGroupAsync(QuestionGroup questionGroup);
        Task<QuestionGroup> DeleteQuestionGroupAsync(int id);
        Task<QuestionGroup> UpdateQuestionGroupAsync(int id, QuestionGroup questionGroup);


    }
}
