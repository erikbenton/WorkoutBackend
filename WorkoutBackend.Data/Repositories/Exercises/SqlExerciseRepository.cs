using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.DataAccess;

namespace WorkoutBackend.Data.Repositories.Exercises;

public class SqlExerciseRepository(string connectionString) : IExerciseRepository
{
    private string _connectionString = connectionString;

    public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var exercises = await connection.QueryAsync<Exercise>(ExerciseDataAccess.GetAllExercises);
        return exercises;
    }

    public async Task<Exercise> GetExerciseByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var exercise = await connection.QueryFirstAsync<Exercise>(ExerciseDataAccess.GetExerciseById, new { id });
        return exercise;
    }

    public async Task<IEnumerable<Exercise>> GetExercisesByNameAsync(string name)
    {
        using var connection = new SqlConnection(_connectionString);
        var exercises = await connection.QueryAsync<Exercise>(ExerciseDataAccess.GetExercisesByName, new { name });
        return exercises;
    }

    public async Task<Exercise> CreateExercise(Exercise exercise)
    {
        using var connection = new SqlConnection(_connectionString);
        int exerciseId = await connection.QueryFirstAsync<int>(ExerciseDataAccess.InsertExerciseWithDetails, exercise);
        return await GetExerciseByIdAsync(exerciseId);
    }

    public async Task<Exercise> UpdateExerciseAsync(Exercise exercise)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(ExerciseDataAccess.UpdateExerciseWithDetails, exercise);
        return await GetExerciseByIdAsync(exercise.Id);
    }

    public async Task DeleteExerciseByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(ExerciseDataAccess.DeleteExerciseById, new { id });
    }

    public async Task<IEnumerable<BodyPartOption>> GetAllBodyPartOptionsAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var bodyPartOptions = await connection.QueryAsync<BodyPartOption>(ExerciseDataAccess.GetAllExerciseBodyPartOptions);
        return bodyPartOptions;
    }

    public async Task<IEnumerable<EquipmentOption>> GetAllEquipmentOptionsAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var equipmentOptions = await connection.QueryAsync<EquipmentOption>(ExerciseDataAccess.GetAllExerciseEquipmentOptions);
        return equipmentOptions;
    }
}
