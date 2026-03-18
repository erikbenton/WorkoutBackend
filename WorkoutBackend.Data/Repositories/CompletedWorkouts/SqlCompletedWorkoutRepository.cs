using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.CompletedWorkouts;

public class SqlCompletedWorkoutRepository(string connectionString) : ICompletedWorkoutRepository
{
    private readonly string _connectionString = connectionString;

    public async Task<CompletedWorkoutEntity> CreateCompletedWorkoutEntityAsync(CompletedWorkoutEntity workout)
    {
        using var connection = new SqlConnection(_connectionString);
        var createdEntity = await connection
            .QueryFirstAsync<CompletedWorkoutEntity>(
                CompletedWorkoutDataAccess.InsertCompletedWorkout, workout);
        return createdEntity;
    }

    public async Task DeleteCompletedWorkoutEntityAsync(int id, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(CompletedWorkoutDataAccess.DeleteCompletedWorkoutById, new { id, userId });
    }

    public async Task<IEnumerable<CompletedWorkoutEntity>> GetAllCompletedWorkoutEntitiesAsync(string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var workoutEntities = await connection
            .QueryAsync<CompletedWorkoutEntity>(
                CompletedWorkoutDataAccess.GetAllCompletedWorkouts, new { userId });
        return workoutEntities;
    }

    public async Task<CompletedWorkoutEntity> GetCompletedWorkoutEntityByIdAsync(int id, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var workoutEntity = await connection
            .QueryFirstAsync<CompletedWorkoutEntity>(
                CompletedWorkoutDataAccess.GetCompletedWorkoutById, new { id, userId });
        return workoutEntity;
    }

    public async Task<IEnumerable<CompletedWorkoutSummaryEntity>> GetCompletedWorkoutSummariesAsync(string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var workoutSummaries = await connection.QueryAsync<CompletedWorkoutSummaryEntity>(CompletedWorkoutDataAccess.GetCompletedWorkoutsSummaries, new { userId });
        return workoutSummaries;
    }

    public async Task<CompletedWorkoutEntity> UpdateCompletedWorkoutEntityAsync(CompletedWorkoutEntity workout)
    {
        using var connection = new SqlConnection(_connectionString);
        var updatedEntity = await connection
            .QueryFirstAsync<CompletedWorkoutEntity>(
                CompletedWorkoutDataAccess.UpdateComepletedWorkoutById, workout);
        return updatedEntity;
    }
}
