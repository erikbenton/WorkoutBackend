namespace WorkoutBackend.Core.Models;

public class CompletedExerciseSet
{
    public int Id { get; set; }
    public int Reps { get; set; }
    public double? Weight { get; set; }
    public int Sort { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int CompletedExerciseGroupId { get; set; }
}