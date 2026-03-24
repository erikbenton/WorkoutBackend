using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.UserStats;

public interface IUserStatsRepository
{
    public Task<UserStatsEntity> GetUserStatsAsync(DateTime endDate, string userId);
}
