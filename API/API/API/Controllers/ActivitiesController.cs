using API.Models;
using API.Services;
using API.Services.Abstractions;
using API.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/activities")]
    [Authorize]
    public class ActivitiesController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly IUserService _userService;

        public ActivitiesController(IActivityService activityService, IUserService userService)
        {
            _activityService = activityService;
            _userService = userService;
        }

        [HttpGet("all/{userId}")]
        public async Task<IActionResult> GetAllActivities(int userId)
        {
            try
            {
                var activities = _activityService.GetUserActivitiesAsync(userId).Result;

                if (activities != null)
                {
                    return Ok(activities);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<Activity>> CreateActivity(Activity activity, int userId)
        {
            try
            {
                await _activityService.CreateActivityAsync(activity, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <returns>No content if successful, NotFound if the activity is not found.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(int id)
        {
            try
            {
                var existingActivity = _activityService.DeleteActivityAsync(id);

                if (existingActivity == null)
                {
                    return NotFound();
                }

                await _activityService.DeleteActivityAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
