namespace WorkoutBackend.Core.Models;

public class UserStats
{
    public int NumberOfDays { get; set; }
    public int NumberOfWorkouts { get; set; }
    public TimeSpan Duration { get; set; }
    public int NumberOfExercises { get; set; }
    public int NumberOfSets { get; set; }
    public int NumberOfReps { get; set; }
    public int TotalVolume { get; set; }
}
