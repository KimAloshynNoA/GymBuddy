using API.Models;

namespace API.Services.Abstractions
{
    public interface IAuthService
    {
        Task<string> GenerateTokenAsync(User user, string password);
    }
}
