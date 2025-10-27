using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Workouts;

public class SqlExerciseSetRepository(string connectionString) : IExerciseSetRepository
{
    private readonly string _connectionString = connectionString;
    public async Task<ExerciseSetEntity> CreateExerciseSetEntityAsync(ExerciseSetEntity exerciseSet)
    {
        using var connection = new SqlConnection(_connectionString);
        var savedId = await connection.QueryFirstAsync<int>(ExerciseSetDataAccess.InsertExerciseSet, exerciseSet);
        return await GetExerciseSetEntityByIdAsync(savedId);
    }

    public async Task DeleteExerciseSetEntityByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(ExerciseSetDataAccess.DeleteExerciseSetById, new { id });
    }

    public async Task<IEnumerable<ExerciseSetEntity>> GetAllExerciseSetEntitiesForExerciseGroupAsync(int exerciseGroupId)
    {
        using var connection = new SqlConnection(_connectionString);
        var sets = await connection.QueryAsync<ExerciseSetEntity>(ExerciseSetDataAccess.GetAllExerciseSetsByGroupId, new { exerciseGroupId });
        return sets;
    }

    public async Task<ExerciseSetEntity> GetExerciseSetEntityByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var set = await connection.QueryFirstAsync<ExerciseSetEntity>(ExerciseSetDataAccess.GetExerciseSetById, new { id });
        return set;
    }

    public async Task<ExerciseSetEntity> UpdateExerciseSetEntityAsync(ExerciseSetEntity exerciseSet)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(ExerciseSetDataAccess.UpdateExerciseSetById, exerciseSet);
        return await GetExerciseSetEntityByIdAsync(exerciseSet.Id);
    }
}
