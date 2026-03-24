using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.UserStats;

public class SqlUserStatsRepository(string connectionString) : IUserStatsRepository
{
    private readonly string _connectionString = connectionString;

    public async Task<UserStatsEntity> GetUserStatsAsync(DateTime endDate, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var userStats = await connection.QueryFirstAsync<UserStatsEntity>(UserStatsDataAccess.GeneralStatsBeforeEqualEndDate, new { endDate, userId });
        return userStats;
    }
}