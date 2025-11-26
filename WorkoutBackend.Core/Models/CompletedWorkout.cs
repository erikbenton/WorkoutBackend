namespace WorkoutBackend.Core.Models;

public class CompletedWorkout
{
    public int Id { get; set; }
    public int? WorkoutId { get; set; }
    public string Name { get; set; }
    public string? Note { get; set; }
    public TimeSpan? Duration { get; set; }
    public DateTime? CreatedAt { get; set; }
    public IEnumerable<CompletedExerciseGroup> CompletedExerciseGroups { get; set; } = [];
}