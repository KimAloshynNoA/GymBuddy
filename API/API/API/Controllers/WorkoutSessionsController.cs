using API.Models;
using API.Services.Abstractions;
using API.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/sessions")]
    [Authorize]
    public class WorkoutSessionsController : Controller
    {
        private readonly IWorkoutSessionService _workoutSessionService;
       // private readonly IUserService _userService;
        public WorkoutSessionsController(IWorkoutSessionService workoutSessionService)
        {
            _workoutSessionService = workoutSessionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetWorkoutSessions([FromBody] Requests.GetWorkoutSessionRequest getSessionsRequest)
        {
            try
            {
                var workoutSessions = _workoutSessionService.GetSessionsByActivityAsync(getSessionsRequest.UserId, getSessionsRequest.ActivityId).Result;

                if (workoutSessions != null)
                {
                    return Ok(workoutSessions);
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

        [HttpPost]
        public async Task<ActionResult<WorkoutSession>> CreateWorkoutSession([FromBody] Requests.CreateWorkoutSessionRequest createSessionRequest)
        {
            try
            {
                await _workoutSessionService.CreateWorkoutSessionAsync(createSessionRequest.WorkoutSession, createSessionRequest.UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <returns>No content if successful, NotFound if the activity is not found.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkoutSession(int id)
        {
            try
            {
                var existingActivity = _workoutSessionService.DeleteWorkoutSessionAsync(id);

                if (existingActivity == null)
                {
                    return NotFound();
                }

                await _workoutSessionService.DeleteWorkoutSessionAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{sessionId}/{excerciseType}")]
        public async Task<IActionResult> GetWorkoutExcercises(int sessionId, string excerciseType)
        {
            try
            {
                var excercises = _workoutSessionService.GetSessionExcercisesByType(excerciseType, sessionId).Result;

                if (excercises != null)
                {
                    return Ok(excercises);
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

    }
}
