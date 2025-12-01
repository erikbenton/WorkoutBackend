namespace WorkoutBackend.Core.Models;

public class CompletedExerciseGroup
{
    public int Id { get; set; }
    public string? Note { get; set; }
    public string? Comment { get; set; }
    public TimeSpan? RestTime { get; set; }
    public int Sort { get; set; }
    public Exercise Exercise { get; set; }
    public DateTime? CreatedAt { get; set; }
    public IEnumerable<CompletedExerciseSet> CompletedExerciseSets { get; set; } = [];
    public int CompletedWorkoutId { get; set; }
}
