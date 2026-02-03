namespace WorkoutBackend.Data.Entities;

public record ExerciseMuscleEntity(int? Id, int ExerciseId, int? MuscleId, int Weight, string? MuscleName)
{ }