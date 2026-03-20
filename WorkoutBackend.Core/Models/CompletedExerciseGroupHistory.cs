namespace WorkoutBackend.Core.Models;

public class CompletedExerciseGroupHistory
{
    public int CompletedExerciseGroupId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Comment { get; set; }
    public IEnumerable<CompletedExerciseSet> CompletedExerciseSets { get; set; } = [];
    public int ExerciseId { get; set; }
}
