namespace WorkoutBackend.Data.Entities;

public record CompletedWorkoutEntity(
    int Id,
    string Name,
    string? Description,
    string ColorRgb,
    string Tag,
    string? Note,
    int DurationInSeconds,
    string UserId,
    DateTime? CreatedAt = null);
