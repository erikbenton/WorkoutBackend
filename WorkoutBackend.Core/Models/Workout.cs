namespace WorkoutBackend.Core.Models;

public class Workout
{
    public int Id { get; set; }

    public int? WorkoutProgramId { get; set; }

    public string Name { get; set; }

    public IEnumerable<ExerciseGroup> ExerciseGroups { get; set; } = [];
}
