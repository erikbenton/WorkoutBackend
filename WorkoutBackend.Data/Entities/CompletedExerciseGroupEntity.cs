namespace WorkoutBackend.Data.Entities;

public record CompletedExerciseGroupEntity(
    int Id,
    string? Note,
    int Sort,
    int ExerciseId,
    int CompletedWorkoutId,
    DateTime? CreatedAt = null)
{ }
