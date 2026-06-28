namespace WorkoutBackend.Api.Dtos;

public record RegistrationRequest(string Email, string Password, string? UserName, double? BodyWeight, string WeightUnit, string DistanceUnit);