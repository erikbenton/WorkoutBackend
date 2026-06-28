using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Api.Dtos;

public record RegistrationResponse(bool Succeeded, IEnumerable<string> errors, string? Email = null, UserInfo? userInfo = null);
