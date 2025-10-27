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

    public async Task DeleteCompletedWorkoutEntityAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(CompletedWorkoutDataAccess.DeleteCompletedWorkoutById, id);
    }

    public async Task<IEnumerable<CompletedWorkoutEntity>> GetAllCompletedWorkoutEntitiesAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var workoutEntities = await connection
            .QueryAsync<CompletedWorkoutEntity>(
                CompletedWorkoutDataAccess.GetAllCompletedWorkouts);
        throw new NotImplementedException();
    }

    public async Task<CompletedWorkoutEntity> GetCompletedWorkoutEntityByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var workoutEntity = await connection
            .QueryFirstAsync<CompletedWorkoutEntity>(
                CompletedWorkoutDataAccess.GetCompletedWorkoutById, id);
        return workoutEntity;
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
