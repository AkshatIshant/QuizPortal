using ResultMicroserviceAPI.Model.Domain;
using System.Runtime.InteropServices;

namespace ResultMicroserviceAPI.Repository.Interfaces
{
    public interface IResultRepository
    {
        Task<IEnumerable<Result>> GetAllResultsAsync();
        Task<Result> GetResultByIdAsync(int id);
        //Task<Result> GetResultByNameAsync(string  username);

        Task<IEnumerable<Result>> GetResultByNameAsync(string username);


        Task<Result> AddResultAsync(Result result);
    }
}
