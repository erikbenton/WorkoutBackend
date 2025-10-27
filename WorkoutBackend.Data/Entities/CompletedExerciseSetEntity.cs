namespace WorkoutBackend.Data.Entities;

public record CompletedExerciseSetEntity(int Id, int Reps, double? Weight, int Sort, int CompletedExerciseGroupId)
{ }
