namespace WorkoutBackend.Data.Entities;

public record SetStatsEntity(
    int NumberOfSets,
    int NumberOfReps,
    int TotalVolume);