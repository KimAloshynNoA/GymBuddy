using API.Models;

namespace API.Services.Abstracts
{
    public interface IWorkoutSessionService
    {
        Task<List<Models.WorkoutSession>> GetSessionsByActivityAsync(int userId, int activityId);
        Task CreateWorkoutSessionAsync(Models.WorkoutSession session, int userId);
        Task<Models.WorkoutSession> GetWorkoutSessionByIdAsync(int id);
        Task DeleteWorkoutSessionAsync(int id);
        Task<List<WorkoutExcercise>> GetSessionExcercisesByType(string type, int workoutSessionId);
    }
}
