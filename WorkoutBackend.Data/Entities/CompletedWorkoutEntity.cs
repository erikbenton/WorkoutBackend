namespace WorkoutBackend.Data.Entities;

public record CompletedWorkoutEntity(
    int Id,
    int? WorkoutId,
    string Name,
    string? Description,
    string? Note,
    int DurationInSeconds,
    DateTime? CreatedAt = null)
{ }
