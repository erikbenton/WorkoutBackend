namespace WorkoutBackend.Data.Entities;

public record ExerciseEntity(int Id,
    string Name,
    string? Instructions,
    int BodyPartId,
    int EquipmentId)
{ }