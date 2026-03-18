using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Core.Models;
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

    public async Task DeleteWorkoutEntityAsync(int id, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(WorkoutDataAccess.DeleteWorkoutById, new { id, userId });

    }

    public async Task<IEnumerable<SetTagOption>> GetAllSetTagOptionsAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var setTags = await connection.QueryAsync<SetTagOption>(WorkoutDataAccess.GetAllSetTagOptions);
        return setTags;
    }

    public async Task<IEnumerable<WorkoutEntity>> GetAllWorkoutEntitiesAsync(string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var workouts = await connection.QueryAsync<WorkoutEntity>(WorkoutDataAccess.GetAllWorkouts, new { userId });
        return workouts;
    }

    public async Task<IEnumerable<WorkoutSummaryEntry>> GetAllWorkoutSummariesEntriesAsync(string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var summaryEntries = await connection.QueryAsync<WorkoutSummaryEntry>(WorkoutDataAccess.GetAllWorkoutSummaryEntries, new { userId });
        return summaryEntries;
    }

    public async Task<WorkoutEntity> GetWorkoutEntityByIdAsync(int id, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var workout = await connection.QueryFirstAsync<WorkoutEntity>(WorkoutDataAccess.GetWorkoutById, new { id, userId });
        return workout;
    }

    public async Task<WorkoutEntity> UpdateWorkoutEntityAsync(WorkoutEntity workout)
    {
        using var connection = new SqlConnection(_connectionString);
        var updatedWorkout = await connection.QueryFirstAsync<WorkoutEntity>(WorkoutDataAccess.UpdateWorkoutById, workout);
        return updatedWorkout;
    }
}
