namespace WorkoutBackend.Api.Dtos;

public record RegistrationResponse(bool Succeeded, IEnumerable<string> errors, string? UserId = null);
