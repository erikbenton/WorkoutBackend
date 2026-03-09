namespace WorkoutBackend.Api.Dtos;

public record UserInfoResponse(bool IsLoggedIn, string? Email = null)
{
}
