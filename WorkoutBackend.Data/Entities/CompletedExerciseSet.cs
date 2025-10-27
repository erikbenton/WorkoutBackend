namespace WorkoutBackend.Data.Entities;

public record CompletedExerciseSet(int Id, int Reps, double? Weight, int Sort, int CompletedExerciseGroupId)
{ }
