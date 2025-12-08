namespace WorkoutBackend.Data.Entities;

public record CompletedExerciseGroupHistoryEntity(
    int CompletedExerciseGroupId,
    int Year,
    int Month,
    int Day,
    string? Comment,
    int ExerciseId)
{
}
