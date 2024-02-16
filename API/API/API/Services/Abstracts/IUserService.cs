using API.Models;
using API.Requests;

namespace API.Services.Abstractions
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserRequest createUserRequest);
        Task CreateUserAsync(User user);
        Task<bool> ExistsUserAsync(string username, string email);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByEmailAsync(string email);
        Task RegisterUserAsync(RegisterUserRequest user);
    }
}
