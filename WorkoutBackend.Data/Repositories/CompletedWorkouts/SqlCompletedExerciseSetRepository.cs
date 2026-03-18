using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.CompletedWorkouts;

public class SqlCompletedExerciseSetRepository(string connectionString) : ICompletedExerciseSetRepository
{
    private readonly string _connectionString = connectionString;

    public async Task<CompletedExerciseSetEntity> CreateCompletedExerciseSetEntityAsync(CompletedExerciseSetEntity exerciseSet)
    {
        using var connection = new SqlConnection(_connectionString);
        var createdEntity = await connection
            .QueryFirstAsync<CompletedExerciseSetEntity>(
                CompletedExerciseSetsDataAccess.InsertCompletedExerciseSet, exerciseSet);
        return createdEntity;
    }

    public async Task DeleteCompletedExerciseSetEntityByIdAsync(int id, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection
            .ExecuteAsync(CompletedExerciseGroupsDataAccess.DeleteCompletedExerciseGroupById, new { id, userId });
    }

    public async Task<IEnumerable<CompletedExerciseSetEntity>> GetAllCompletedExerciseSetEntitiesForCompletedGroupAsync(int completedExerciseGroupId, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var setEntities = await connection
            .QueryAsync<CompletedExerciseSetEntity>(
                CompletedExerciseSetsDataAccess.GetCompletedExerciseSetsByCompletedGroupId, new { completedExerciseGroupId, userId });
        return setEntities;
    }

    public async Task<CompletedExerciseSetEntity> GetCompletedExerciseSetEntityByIdAsync(int id, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var setEntity = await connection
            .QueryFirstAsync<CompletedExerciseSetEntity>(
                CompletedExerciseSetsDataAccess.GetCompletedExerciseSetById, new { id, userId });
        return setEntity;
    }

    public async Task<CompletedExerciseSetEntity> UpdateCompletedExerciseSetEntityAsync(CompletedExerciseSetEntity exerciseSet)
    {
        using var connection = new SqlConnection(_connectionString);
        var updatedEntity = await connection
            .QueryFirstAsync<CompletedExerciseSetEntity>(
                CompletedExerciseSetsDataAccess.UpdateCompletedExerciseSetById, exerciseSet);
        return updatedEntity;
    }
}
