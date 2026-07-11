namespace WorkoutBackend.Core.Models;

public class Workout
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? Name { get; set; }

    public string ColorRgb { get; set; } = string.Empty;

    public string Tag { get; set; } = string.Empty;

    public IEnumerable<ExerciseGroup> ExerciseGroups { get; set; } = [];
}
