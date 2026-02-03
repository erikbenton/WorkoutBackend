namespace WorkoutBackend.Data.Entities;

public record ExerciseEntity(int Id,
    string Name,
    string? Instructions,
    string EquipmentName)
{ }