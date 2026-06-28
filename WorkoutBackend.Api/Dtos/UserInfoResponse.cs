using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Api.Dtos;

public record UserInfoResponse(bool IsLoggedIn, string? Email = null, UserInfo? UserInfo = null);