namespace WorkoutBackend.Core.Models;

public class WorkoutSummary
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<string> ExerciseNames { get; set; } = [];
}
