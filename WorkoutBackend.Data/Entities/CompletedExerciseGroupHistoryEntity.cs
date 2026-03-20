namespace WorkoutBackend.Data.Entities;

public record CompletedExerciseGroupHistoryEntity(
    int CompletedExerciseGroupId,
    string? Comment,
    int ExerciseId,
    string UserId,
    DateTime CreatedAt);
