using Microsoft.EntityFrameworkCore;
using ResultMicroserviceAPI.Data;
using ResultMicroserviceAPI.Model.Domain;
using ResultMicroserviceAPI.Repository.Interfaces;

namespace ResultMicroserviceAPI.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly ResultDbContext resultDbContext;
        public ResultRepository(ResultDbContext _resultDbContext)
        {
            resultDbContext = _resultDbContext;
        }

       

        public async Task<Result> GetResultByIdAsync(int id)
        {
            return await resultDbContext.Results.FirstOrDefaultAsync(x => x.Id == id);
        }

        //public async Task<Result> GetResultByNameAsync(string  username)
        //{
        //    return await resultDbContext.Results.FirstOrDefaultAsync(x => x.UserName == username);
        //}

        public async Task<IEnumerable<Result>> GetResultByNameAsync(string username)
        {
            List<Result> result = await resultDbContext.Results.Where(x => x.UserName.ToLower() == username.ToLower()).ToListAsync();
            return result;
        }


            public async Task<IEnumerable<Result>> GetAllResultsAsync()
        {
            return await resultDbContext.Results.ToListAsync();
        }

        public async Task<Result> AddResultAsync(Result result)
        {
            await resultDbContext.AddAsync(result);
            await resultDbContext.SaveChangesAsync();
            return result;
        }
    }
}
