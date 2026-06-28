namespace WorkoutBackend.Data.Entities;

record class UserInfoEntity(
    string? Username,
    double? BodyWeight,
    string WeightUnit,
    string DistanceUnit,
    string UserId);