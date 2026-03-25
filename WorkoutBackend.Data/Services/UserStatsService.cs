using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Repositories.UserStats;

namespace WorkoutBackend.Data.Services;

public class UserStatsService(IUserStatsRepository userStatsRepository) : IUserStatsService
{
    private readonly IUserStatsRepository _userStatsRepository = userStatsRepository;

    public async Task<UserStats> GetUserStatsAsync(int numberOfDays, string userId)
    {
        var today = DateTime.UtcNow;
        var enddate = today.AddDays(-numberOfDays);
        var userStatsEntity = await _userStatsRepository.GetUserStatsAsync(enddate, userId);
        return new UserStats()
        {
            NumberOfDays = numberOfDays,
            NumberOfWorkouts = userStatsEntity.NumberOfWorkouts,
            Duration = TimeSpan.FromSeconds(userStatsEntity.DurationInSeconds),
            DurationInSeconds = userStatsEntity.DurationInSeconds,
            NumberOfSets = userStatsEntity.NumberOfSets,
            NumberOfReps = userStatsEntity.NumberOfReps,
            TotalVolume = userStatsEntity.TotalVolume
        };
    }
}