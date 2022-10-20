using UserMicroserviceAPI.Models.Domain;

namespace UserMicroserviceAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> RegisterUserAsync(User user);
        Task<User> AddUserAsync(User user);
        Task<User> GetUserInfoAsync(string name);
        Task<User> DeleteUserAsync(int id);
        Task<User> UpdateUserAsync(int id, User user);
        List<User> GetUsers();


    }
}
