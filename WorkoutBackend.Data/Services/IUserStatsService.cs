using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Services;

public interface IUserStatsService
{
    public Task<UserStats> GetUserStatsAsync(int numberOfDays, string userId);
}
