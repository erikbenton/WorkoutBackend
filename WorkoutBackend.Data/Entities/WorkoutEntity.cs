namespace WorkoutBackend.Data.Entities;

public record WorkoutEntity(int Id,
    string Name,
    int? ProgramId)
{ }