namespace WorkoutBackend.Core.Models;

public class ExerciseSet
{
    public int Id { get; set; }
    public int Reps { get; set; }
    public double Weight { get; set; }
    public int Sort { get; set; }
    public int ExerciseGroupId { get; set; }
}
