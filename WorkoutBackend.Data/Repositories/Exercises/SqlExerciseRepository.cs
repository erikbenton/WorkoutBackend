using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Exercises;

public class SqlExerciseRepository(string connectionString) : IExerciseRepository
{
    private string _connectionString = connectionString;

    public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
    {
        using var connection = new SqlConnection(_connectionString);

        var results = await connection.QueryMultipleAsync(ExerciseDataAccess.GetAllExercises);

        var exercises = results.Read<Exercise>();
        var exercisesMuscles = results.Read<MuscleEntity>();

        foreach (var exercise in exercises)
        {
            var muscleData = exercisesMuscles.Where(exMus => exMus.ExerciseId == exercise.Id);
            exercise.Muscles = muscleData.Select(data => new MuscleData() { Name = data.MuscleName, Weight = data.Weight, ColorRgb = data.ColorRgb });
        }

        return exercises.AsEnumerable();
    }

    public async Task<Exercise> GetExerciseByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        
        var results = await connection.QueryMultipleAsync(ExerciseDataAccess.GetExerciseById, new { id });
        
        var exercise = results
            .Read<Exercise>()
            .First();
        
        exercise.Muscles = results
            .Read<MuscleDataEntity>()
            .Select(entity => new MuscleData() { Name = entity.MuscleName, Weight = entity.Weight, ColorRgb = entity.ColorRgb });
        
        return exercise;
    }

    public async Task<IEnumerable<Exercise>> GetExercisesByNameAsync(string name)
    {
        using var connection = new SqlConnection(_connectionString);
        var exercises = await connection.QueryAsync<Exercise>(ExerciseDataAccess.GetExercisesByName, new { name });
        return exercises;
    }

    public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
    {
        using var connection = new SqlConnection(_connectionString);
        int exerciseId = await connection.QueryFirstAsync<int>(ExerciseDataAccess.InsertExerciseWithDetails, exercise);
        var exerciseMuscleEntities = exercise.Muscles?
            .Select(mus => new ExerciseMuscleEntity(null, exerciseId, null, mus.Weight, mus.Name)) ?? [];

        await connection.ExecuteAsync(ExerciseDataAccess.InsertExerciseMuscles, exerciseMuscleEntities);
        return await GetExerciseByIdAsync(exerciseId);
    }

    public async Task<Exercise> UpdateExerciseAsync(Exercise exercise)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(ExerciseDataAccess.UpdateExerciseWithDetails, exercise);

        await connection.ExecuteAsync(ExerciseDataAccess.DeleteExerciseMusclesByExerciseId, new { ExerciseId = exercise.Id });

        var exerciseMuscleEntities = exercise.Muscles?
            .Select(mus => new ExerciseMuscleEntity(null, exercise.Id, null, mus.Weight, mus.Name)) ?? [];

        await connection.ExecuteAsync(ExerciseDataAccess.InsertExerciseMuscles, exerciseMuscleEntities);

        return await GetExerciseByIdAsync(exercise.Id);
    }

    public async Task DeleteExerciseByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(ExerciseDataAccess.DeleteExerciseById, new { id });
        await connection.ExecuteAsync(ExerciseDataAccess.DeleteExerciseMusclesByExerciseId, new { ExerciseId = id });
    }

    public async Task<IEnumerable<MuscleOption>> GetAllMuscleOptionsAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var muscleOptions = await connection.QueryAsync<MuscleOption>(ExerciseDataAccess.GetAllExerciseMuscleOptions);
        return muscleOptions;
    }

    public async Task<IEnumerable<EquipmentOption>> GetAllEquipmentOptionsAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var equipmentOptions = await connection.QueryAsync<EquipmentOption>(ExerciseDataAccess.GetAllExerciseEquipmentOptions);
        return equipmentOptions;
    }
}
