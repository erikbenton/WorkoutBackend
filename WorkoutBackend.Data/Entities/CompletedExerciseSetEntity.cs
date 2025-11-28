namespace WorkoutBackend.Data.Entities;

public record CompletedExerciseSetEntity(
    int Id,
    int Reps,
    double? Weight,
    int? MinReps,
    int? MaxReps,
    string? SetType,
    int Sort,
    int CompletedExerciseGroupId,
    DateTime? CreatedAt = null)
{ }
