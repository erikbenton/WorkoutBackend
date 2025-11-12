namespace WorkoutBackend.Core.Models;

public class CompletedExerciseGroupHistory
{
    public int CompletedExerciseGroupId { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public IEnumerable<CompletedExerciseSet> CompletedExerciseSets { get; set; } = [];
    public int ExerciseId { get; set; }
}
