namespace WorkoutBackend.Data.Entities;

public record CompletedWorkoutSummaryEntity(
    int Id,
    string Name,
    int NumberOfExerciseGroups,
    int DurationInSeconds,
    DateTime CompletedAt)
{ }
