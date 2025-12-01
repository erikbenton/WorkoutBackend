namespace WorkoutBackend.Data.Entities;

public record CompletedExerciseGroupEntity(
    int Id,
    string? Note,
    string? Comment,
    int? RestTimeInSeconds,
    int Sort,
    int ExerciseId,
    int CompletedWorkoutId,
    DateTime? CreatedAt = null)
{ }
