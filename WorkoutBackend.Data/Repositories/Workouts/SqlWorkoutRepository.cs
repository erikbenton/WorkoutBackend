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
        var savedWorkout = workout.ProgramId == null
            ? await connection.QueryFirstAsync<WorkoutEntity>(WorkoutDataAccess.InsertWorkoutNoProgramId, workout)
            : await connection.QueryFirstAsync<WorkoutEntity>(WorkoutDataAccess.InsertWorkoutWithProgramId, workout);

        return savedWorkout;
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
        var updatedWorkout = await connection.QueryFirstAsync<WorkoutEntity>(WorkoutDataAccess.UpdateWorkoutById, workout);
        return updatedWorkout;
    }
}
