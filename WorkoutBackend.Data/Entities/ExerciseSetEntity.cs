namespace WorkoutBackend.Data.Entities;

public record ExerciseSetEntity(int Id,
    int? MinReps,
    int? MaxReps,
    string? SetType,
    int Sort,
    int ExerciseGroupId)
{ }
