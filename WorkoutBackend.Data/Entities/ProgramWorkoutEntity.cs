namespace WorkoutBackend.Data.Entities;

public record ProgramWorkoutEntity(int? Id, int ProgramId, int WorkoutId, int Sort, string UserId);
