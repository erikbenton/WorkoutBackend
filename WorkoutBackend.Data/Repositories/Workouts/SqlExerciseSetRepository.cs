using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Workouts;

public class SqlExerciseSetRepository(string connectionString) : IExerciseSetRepository
{
    private readonly string _connectionString = connectionString;
    public async Task<ExerciseSetEntity> CreateExerciseSetEntityAsync(ExerciseSetEntity exerciseSet)
    {
        using var connection = new SqlConnection(_connectionString);
        var savedSet = await connection.QueryFirstAsync<ExerciseSetEntity>(ExerciseSetDataAccess.InsertExerciseSet, exerciseSet);
        return savedSet;
    }

    public async Task DeleteExerciseSetEntityByIdAsync(int id, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(ExerciseSetDataAccess.DeleteExerciseSetById, new { id, userId });
    }

    public async Task<IEnumerable<ExerciseSetEntity>> GetAllExerciseSetEntitiesForExerciseGroupAsync(int exerciseGroupId, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var sets = await connection.QueryAsync<ExerciseSetEntity>(ExerciseSetDataAccess.GetAllExerciseSetsByGroupId, new { exerciseGroupId, userId });
        return sets;
    }

    public async Task<ExerciseSetEntity> GetExerciseSetEntityByIdAsync(int id, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var set = await connection.QueryFirstAsync<ExerciseSetEntity>(ExerciseSetDataAccess.GetExerciseSetById, new { id, userId });
        return set;
    }

    public async Task<ExerciseSetEntity> UpdateExerciseSetEntityAsync(ExerciseSetEntity exerciseSet)
    {
        using var connection = new SqlConnection(_connectionString);
        var updatedSet = await connection.QueryFirstAsync<ExerciseSetEntity>(ExerciseSetDataAccess.UpdateExerciseSetById, exerciseSet);
        return updatedSet;
    }
}
