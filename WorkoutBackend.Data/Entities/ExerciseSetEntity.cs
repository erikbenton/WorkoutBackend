namespace WorkoutBackend.Data.Entities;

public record ExerciseSetEntity(int Id,
    int? MinReps,
    int? MaxReps,
    double? Weight,
    int Sort,
    int ExerciseGroupId)
{ }
