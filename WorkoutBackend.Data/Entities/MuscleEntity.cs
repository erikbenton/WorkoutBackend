namespace WorkoutBackend.Data.Entities;

public record MuscleEntity(int? Id, int ExerciseId, int? MuscleId, int Weight, string? MuscleName, string ColorRgb);