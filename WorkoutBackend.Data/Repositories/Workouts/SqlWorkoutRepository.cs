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

    public async Task<WorkoutEntity> GetWorkoutEntityByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var workout = await connection.QueryFirstAsync<WorkoutEntity>(WorkoutDataAccess.GetWorkoutById, new { id });
        return workout;
    }

    public async Task<WorkoutEntity> SaveWorkoutAsync(Workout workout)
    {
        var dbWorkout = new WorkoutEntity(workout.Id,
            workout.Name,
            workout.WorkoutProgramId);

        using var connection = new SqlConnection(_connectionString);
        var savedWorkout = dbWorkout.Id == 0
            ? await CreateWorkoutEntityAsync(dbWorkout)
            : await UpdateWorkoutEntityAsync(dbWorkout);

        return savedWorkout;
    }

    public async Task<WorkoutEntity> UpdateWorkoutEntityAsync(WorkoutEntity workout)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(WorkoutDataAccess.UpdateWorkoutById, workout);
        return await GetWorkoutEntityByIdAsync(workout.Id);
    }
}
