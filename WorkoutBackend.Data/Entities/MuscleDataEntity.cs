namespace WorkoutBackend.Data.Entities;

public record MuscleDataEntity(int? Id, int ExerciseId, int? MuscleId, int Weight, string? MuscleName, string ColorRgb);