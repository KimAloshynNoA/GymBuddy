using API.Models;
using API.Seeds.Abstracts;
using API.Services.Abstractions;

namespace API.Seeds
{
    public class UserDataGenerator : IDataGenerator
    {
        private static readonly User[] _usersData =
        {
            new User
            {
                UserName = "admin",
                Password = "admin",
                Email = "admin@admin.com",
                Name = "Administrator",
                Surname = "Administrator",
            },
            new User
            {
                UserName = "Kimba",
                Password = "kimkim123",
                Email = "kimNonexsistingMailBla@email.com",
                Name = "Kim",
                Surname = "Aloshyn",
            },
        };

        private readonly IUserService _userService;

        public UserDataGenerator(IUserService usersService)
        {
            _userService = usersService;
        }

        public async Task SeedAsync()
        {
            foreach (User user in _usersData)
            {
                bool exists = await _userService.ExistsUserAsync(user.UserName, user.Email);
                if (!exists)
                {
                    await _userService.CreateUserAsync(user);
                }
            }
        }
    }
}
