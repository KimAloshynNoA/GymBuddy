using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Requests
{
    public class CreateWorkoutSessionRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public WorkoutSession WorkoutSession { get; set; }
    }
}
