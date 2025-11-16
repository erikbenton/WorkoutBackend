namespace WorkoutBackend.Data.Entities;

public record WorkoutEntity(int Id,
    string Name,
    string? Description,
    int? ProgramId)
{ }