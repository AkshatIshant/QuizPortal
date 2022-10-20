using Microsoft.EntityFrameworkCore;
using ResultMicroserviceAPI.Model.Domain;

namespace ResultMicroserviceAPI.Data
{
    public class ResultDbContext : DbContext
    {
        public ResultDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Result> Results { get; set; }
    }
}
