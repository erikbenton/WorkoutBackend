namespace WorkoutBackend.Data.Entities;

public record WorkoutSummaryEntry(int WorkoutId, int ExerciseGroupId, string WorkoutName, string ExerciseName)
{
}
