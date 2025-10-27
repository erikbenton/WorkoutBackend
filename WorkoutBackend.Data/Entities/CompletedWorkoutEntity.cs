namespace WorkoutBackend.Data.Entities;

public record CompletedWorkoutEntity(int Id, int? WorkouId, string Name, string? Note, int DurationInSeconds, DateTime? CreatedAt)
{ }
