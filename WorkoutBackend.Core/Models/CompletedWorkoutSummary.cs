namespace WorkoutBackend.Core.Models;

public class CompletedWorkoutSummary
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfExerciseGroups {  get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime CompletedAt { get; set; }
}
