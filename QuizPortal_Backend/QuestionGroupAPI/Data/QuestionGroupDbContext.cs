using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using QuestionGroupMicroserviceAPI.Models.Domain;
using System.Collections.Generic;

namespace QuestionGroupMicroserviceAPI.Data
{
    public class QuestionGroupDbContext:DbContext
    {
        public QuestionGroupDbContext(DbContextOptions options) : base(options)
        {
            //var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            //try
            //{
            //    if (databaseCreator != null)
            //    {
            //        if (databaseCreator.CanConnect()) databaseCreator.Create();
            //        if (databaseCreator.HasTables()) databaseCreator.CreateTables();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
        public DbSet<QuestionGroup> QuestionGroups { get; set; }
        
    }
}
