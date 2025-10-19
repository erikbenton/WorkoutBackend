namespace WorkoutBackend.Core.Models;

public class WorkoutProgram
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public IEnumerable<Workout> Workouts { get; set; }
}
