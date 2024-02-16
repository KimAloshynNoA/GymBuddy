using API.Models;
using API.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace API.Services
{
    public class ActivityService : IActivityService
    {
        private readonly DataContext _applicationDbContext;

        public ActivityService(DataContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Models.Activity>> GetUserActivitiesAsync(int userId)
        {
            var user = await _applicationDbContext.Users.Include(i => i.Activities)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return user.Activities.ToList();
        }
        public async Task CreateActivityAsync(Models.Activity activity, int userId)
        {
            try
            {
                var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
                user?.Activities.Add(activity);

                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Activity create error");
            }
        }

        public async Task<Models.Activity> GetActivityByIdAsync(int id)
        {
            return await _applicationDbContext.Activities
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteActivityAsync(int id)
        {
            var activityToDelete = await _applicationDbContext.Activities.FirstOrDefaultAsync(x => x.Id == id);

            if (activityToDelete != null)
            {
                try
                {
                    _applicationDbContext.Activities.Remove(activityToDelete);
                    await _applicationDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Activity deletion error");
                }
            }
        }

    }
}
