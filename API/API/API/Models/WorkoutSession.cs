namespace API.Models
{
    public class WorkoutSession : BaseEntity
    {
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public Activity Activity { get; set; }
        public List<WorkoutExcercise> Excercises { get; set; } = new List<WorkoutExcercise>();
    }
}
