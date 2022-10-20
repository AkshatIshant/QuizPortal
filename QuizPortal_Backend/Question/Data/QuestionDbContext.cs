using Microsoft.EntityFrameworkCore;
using QuestionMicroserviceAPI.Models.Domain;

namespace QuestionMicroserviceAPI.Data
{
    public class QuestionDbContext:DbContext
    {
        public QuestionDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Question> Questions { get; set; }
    }
}
