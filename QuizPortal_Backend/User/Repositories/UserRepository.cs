using UserMicroserviceAPI.Repositories.Interfaces;
using UserMicroserviceAPI.Data;
using UserMicroserviceAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace UserMicroserviceAPI.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly UserMicroserviceAPIDB userDbContext;
        public UserRepository(UserMicroserviceAPIDB _userDbContext) 
        {
            userDbContext = _userDbContext;
        }       

        public async Task<User> RegisterUserAsync(User user)
        {
            await userDbContext.AddAsync(user);
            await userDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserInfoAsync(string name)
        {
            return await userDbContext.Users.FirstOrDefaultAsync(x => x.UserName == name);
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var user = await userDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            else
            {
                userDbContext.Remove(user);
                await userDbContext.SaveChangesAsync();
            }
            return user;
        }

        public List<User> GetUsers()
        {
            return  userDbContext.Users.ToList();
        }

        public async Task<User> UpdateUserAsync(int id, User _user)
        {
            var user = await userDbContext.Users.Where(x => x.Id == id).SingleAsync();



            user.UserName = _user.UserName;
            user.Password = _user.Password;
            user.FirstName = _user.FirstName;
            user.LastName = _user.LastName;
            user.Email = _user.Email;
            user.Contact = _user.Contact;
            user.Role = _user.Role;
            user.ConfirmPassword = _user.ConfirmPassword;



            userDbContext.Users.Update(user);
            await userDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await userDbContext.AddAsync(user);
            await userDbContext.SaveChangesAsync();
            return user;
        }

    }
}

