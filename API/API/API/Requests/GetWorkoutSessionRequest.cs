using System.ComponentModel.DataAnnotations;

namespace API.Requests
{
    public class GetWorkoutSessionRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ActivityId { get; set; }
    }
}
