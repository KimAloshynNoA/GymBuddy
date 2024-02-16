namespace API.Services.Abstracts
{
    public interface IActivityService
    {
        Task<List<Models.Activity>> GetUserActivitiesAsync(int userId);
        Task CreateActivityAsync(Models.Activity activity, int userId);
        Task<Models.Activity> GetActivityByIdAsync(int id);
        Task DeleteActivityAsync(int id);
    }
}
