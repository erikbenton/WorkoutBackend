namespace WorkoutBackend.Data.Entities;

public record UserStatsEntity(
    int NumberOfWorkouts,
    int DurationInSeconds,
    int NumberOfExercises,
    int NumberOfSets,
    int NumberOfReps,
    int TotalVolume);