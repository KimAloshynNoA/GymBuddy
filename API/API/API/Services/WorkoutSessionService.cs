using API.Models;
using API.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class WorkoutSessionService : IWorkoutSessionService
    {
        private readonly DataContext _applicationDbContext;

        public WorkoutSessionService(DataContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<List<Models.WorkoutSession>> GetSessionsByActivityAsync(int userId, int activityId)
        {
            var user = await _applicationDbContext.Users
                .FirstOrDefaultAsync(u => u.Id == userId);
            return user.WorkoutSessions.Where(x => x.Activity.Id == activityId).ToList();
        }

        public async Task CreateWorkoutSessionAsync(Models.WorkoutSession session, int userId)
        {
            try
            {
                var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
                user?.WorkoutSessions.Add(session);

                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Workout session create error");
            }
        }

        public async Task<Models.WorkoutSession> GetWorkoutSessionByIdAsync(int id)
        {
            return await _applicationDbContext.WorkoutSessions
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteWorkoutSessionAsync(int id)
        {
            var sessionToDelete = await _applicationDbContext.WorkoutSessions.FirstOrDefaultAsync(x => x.Id == id);

            if (sessionToDelete != null)
            {
                try
                {
                    _applicationDbContext.WorkoutSessions.Remove(sessionToDelete);
                    await _applicationDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Workout session deletion error");
                }
            }
        }

        public async Task<List<WorkoutExcercise>> GetSessionExcercisesByType(string type, int workoutSessionId)
        {
            var workoutSession= await _applicationDbContext.WorkoutSessions.FirstOrDefaultAsync(x => x.Id == workoutSessionId);
            return workoutSession.Excercises.Where(x => x.Excercise.Type ==  type).ToList();
        }

    }
}
