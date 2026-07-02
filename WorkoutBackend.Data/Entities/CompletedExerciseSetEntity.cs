namespace WorkoutBackend.Data.Entities;

public record CompletedExerciseSetEntity(
    int Id,
    int? Reps,
    double? Weight,
    int? DurationInSeconds,
    double? DistanceInMiles,
    int? MinReps,
    int? MaxReps,
    int? TargetDurationInSeconds,
    double? TargetDistanceInMiles,
    string WeightUnit,
    string DistanceUnit,
    int? SetTagId,
    int Sort,
    int CompletedExerciseGroupId,
    string UserId,
    DateTime? CreatedAt = null);
