namespace API.Models
{
    public class WorkoutExcercise : BaseEntity
    {
        public Excercise Excercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
    }
}
