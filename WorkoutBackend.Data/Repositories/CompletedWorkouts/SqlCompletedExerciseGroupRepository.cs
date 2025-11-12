using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.CompletedWorkouts;

public class SqlCompletedExerciseGroupRepository(string connectionString) : ICompletedExerciseGroupRepository
{
    private readonly string _connectionString = connectionString;

    public async Task<CompletedExerciseGroupEntity> CreateCompletedExerciseGroupEntityAsync(CompletedExerciseGroupEntity exerciseGroup)
    {
        using var connection = new SqlConnection(_connectionString);
        var savedEntity = await connection
            .QueryFirstAsync<CompletedExerciseGroupEntity>(
                CompletedExerciseGroupsDataAccess.InsertCompletedExerciseGroup, exerciseGroup);
        return savedEntity;
    }

    public async Task DeleteCompletedExerciseGroupEntityByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(CompletedExerciseGroupsDataAccess.DeleteCompletedExerciseGroupById, new { id });
    }

    public async Task<IEnumerable<CompletedExerciseGroupEntity>> GetAllCompletedExerciseGroupEntitiesForCompletedWorkoutAsync(int completedWorkoutId)
    {
        using var connection = new SqlConnection(_connectionString);
        var groupEntities = await connection
            .QueryAsync<CompletedExerciseGroupEntity>(
                CompletedExerciseGroupsDataAccess.GetCompletedExerciseGroupsByCompletedWorkoutId, new { completedWorkoutId });
        return groupEntities;
    }

    public async Task<CompletedExerciseGroupEntity> GetCompletedExerciseGroupEntityByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var groupEntity = await connection
            .QueryFirstAsync<CompletedExerciseGroupEntity>(
                CompletedExerciseGroupsDataAccess.GetCompletedExerciseGroupById, new { id });
        return groupEntity;
    }

    public async Task<IEnumerable<CompletedExerciseGroupHistoryEntity>> GetCompletedGroupHistoryByExerciseIdAsync(int exerciseId)
    {
        using var connection = new SqlConnection(_connectionString);
        var groupHistory = await connection.QueryAsync<CompletedExerciseGroupHistoryEntity>(
            CompletedExerciseGroupsDataAccess.GetCompletedGroupHistoryByExerciseId, new { exerciseId });
        return groupHistory;
    }

    public async Task<CompletedExerciseGroupEntity> UpdateCompletedExerciseGroupEntityAsync(CompletedExerciseGroupEntity exerciseGroup)
    {
        using var connection = new SqlConnection(_connectionString);
        var updatedEntity = await connection
            .QueryFirstAsync<CompletedExerciseGroupEntity>(
                CompletedExerciseGroupsDataAccess.UpdateCompletedExerciseGroupById, exerciseGroup);
        return updatedEntity;
    }
}