namespace WorkoutBackend.Data.Entities;

public record ProgramEntity(int Id, string Name, string ColorRgb, string Tag, string? Description, string UserId);
