using UserMicroserviceAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace UserMicroserviceAPI.Data
{
    public class UserMicroserviceAPIDB:DbContext
    {
        public UserMicroserviceAPIDB(DbContextOptions options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
