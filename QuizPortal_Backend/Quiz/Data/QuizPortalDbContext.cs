using QuizAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace QuizAPI.Data
{
    public class QuizPortalDbContext : DbContext
    {
     
            public QuizPortalDbContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<Quiz> Quizs { get; set; }
        
    }
}
