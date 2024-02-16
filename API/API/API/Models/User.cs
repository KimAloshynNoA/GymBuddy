namespace API.Models
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public List<Activity> Activities { get; set; } = new List<Activity>();
        public List<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
    }
}

