using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Workouts;

public class SqlWorkoutRepository(string connectionString) : IWorkoutRepository
{
    private readonly string _connectionString = connectionString;

    public async Task<WorkoutEntity> CreateWorkoutEntityAsync(WorkoutEntity workout)
    {
        using var connection = new SqlConnection(_connectionString);
        var savedId = workout.ProgramId == null
            ? await connection.QueryFirstAsync<int>(WorkoutDataAccess.InsertWorkoutNoProgramId, workout)
            : await connection.QueryFirstAsync<int>(WorkoutDataAccess.InsertWorkoutWithProgramId, workout);

        return await GetWorkoutEntityByIdAsync(savedId);
    }

    public async Task DeleteWorkoutEntityAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(WorkoutDataAccess.DeleteWorkoutById, new { id });

    }

    public async Task<IEnumerable<WorkoutEntity>> GetAllWorkoutEntitiesAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var workouts = await connection.QueryAsync<WorkoutEntity>(WorkoutDataAccess.GetAllWorkouts);
        return workouts;
    }

    public async Task<IEnumerable<WorkoutSummaryEntry>> GetAllWorkoutSummariesEntriesAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var summaryEntries = await connection.QueryAsync<WorkoutSummaryEntry>(WorkoutDataAccess.GetAllWorkoutSummaryEntries);
        return summaryEntries;
    }

    public async Task<WorkoutEntity> GetWorkoutEntityByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var workout = await connection.QueryFirstAsync<WorkoutEntity>(WorkoutDataAccess.GetWorkoutById, new { id });
        return workout;
    }

    public async Task<WorkoutEntity> UpdateWorkoutEntityAsync(WorkoutEntity workout)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(WorkoutDataAccess.UpdateWorkoutById, workout);
        return await GetWorkoutEntityByIdAsync(workout.Id);
    }
}
