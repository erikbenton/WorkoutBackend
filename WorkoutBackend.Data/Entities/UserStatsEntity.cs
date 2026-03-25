namespace WorkoutBackend.Data.Entities;


public record UserStatsEntity
{
    public int NumberOfWorkouts { get; init; }
    public int DurationInSeconds { get; init; }
    public int NumberOfSets { get; init; }
    public int NumberOfReps { get; init; }
    public int TotalVolume { get; init; }

    public UserStatsEntity(WorkoutStatsEntity workoutStats, SetStatsEntity setStats)
    {
        NumberOfWorkouts = workoutStats.NumberOfWorkouts;
        DurationInSeconds = workoutStats.DurationInSeconds;
        NumberOfSets = setStats.NumberOfSets;
        NumberOfReps = setStats.NumberOfReps;
        TotalVolume = setStats.TotalVolume;
    }
}