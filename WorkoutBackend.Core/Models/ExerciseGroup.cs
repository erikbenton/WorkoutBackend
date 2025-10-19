namespace WorkoutBackend.Core.Models;

public class ExerciseGroup
{
    public int Id { get; set; }

    public int WorkoutId { get; set; }

    public Exercise Exercise { get; set; }

    public string? Note { get; set; }

    public int Sort { get; set; }

    public IEnumerable<ExerciseSet> ExerciseSets { get; set; } = [];
}
