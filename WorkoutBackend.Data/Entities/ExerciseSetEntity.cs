namespace WorkoutBackend.Data.Entities;

public record ExerciseSetEntity(int Id,
    int? MinReps,
    int? MaxReps,
    int? SetTagId,
    int Sort,
    int ExerciseGroupId,
    string UserId);
