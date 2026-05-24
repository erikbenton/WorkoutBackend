using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Exercises;

public class SqlExerciseRepository(string connectionString) : IExerciseRepository
{
    private string _connectionString = connectionString;

    public async Task<IEnumerable<Exercise>> GetAllExercisesAsync(string? userId = null)
    {
        using var connection = new SqlConnection(_connectionString);

        var results = await connection.QueryMultipleAsync(ExerciseDataAccess.GetAllExercises);

        var exerciseEntities = results.Read<ExerciseEntity>();
        var exercisesMuscles = results.Read<MuscleEntity>();

        var exercises = new List<Exercise>();

        foreach (var exerciseEntity in exerciseEntities)
        {
            // get the muscle data for the exercise
            var muscleData = exercisesMuscles
                .Where(exMus => exMus.ExerciseId == exerciseEntity.Id)
                .Select(data => new MuscleData() { Name = data.MuscleName, Weight = data.Weight, ColorRgb = data.ColorRgb });
            
            // create the full exercise
            exercises.Add(new Exercise()
            {
                Id = exerciseEntity.Id,
                Name = exerciseEntity.Name,
                Category = exerciseEntity.Category,
                Equipment = exerciseEntity.Equipment,
                Instructions = exerciseEntity.Instructions,
                Muscles = muscleData,
                RequestedByUser = userId is not null && userId == exerciseEntity.UserId
            });
        }

        return exercises;
    }

    public async Task<Exercise> GetExerciseByIdAsync(int id, string? userId = null)
    {
        using var connection = new SqlConnection(_connectionString);
        
        var results = await connection.QueryMultipleAsync(ExerciseDataAccess.GetExerciseById, new { id });
        
        var exerciseEntity = results
            .Read<ExerciseEntity>()
            .First();
        
        var muscles = results
            .Read<MuscleDataEntity>()
            .Select(entity => new MuscleData() { Name = entity.MuscleName, Weight = entity.Weight, ColorRgb = entity.ColorRgb });
        
        return new Exercise()
        {
            Id = exerciseEntity.Id,
            Name = exerciseEntity.Name,
            Category = exerciseEntity.Category,
            Equipment = exerciseEntity.Equipment,
            Instructions = exerciseEntity.Instructions,
            Muscles = muscles,
            RequestedByUser = userId is not null && userId == exerciseEntity.UserId
        };
    }

    public async Task<IEnumerable<Exercise>> GetExercisesByNameAsync(string name, string? userId = null)
    {
        using var connection = new SqlConnection(_connectionString);
        var exercises = await connection.QueryAsync<Exercise>(ExerciseDataAccess.GetExercisesByName, new { name });
        return exercises;
    }

    public async Task<Exercise> CreateExerciseAsync(Exercise exercise, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var insertEntity = new ExerciseEntity(
            exercise.Id,
            (exercise.Name ?? ""),
            exercise.Instructions,
            (exercise.Category ?? ""),
            (exercise.Equipment ?? ""),
            userId);
        int exerciseId = await connection.QueryFirstAsync<int>(ExerciseDataAccess.InsertExerciseWithDetails, insertEntity);
        var exerciseMuscleEntities = exercise.Muscles?
            .Select(mus => new ExerciseMuscleEntity(null, exerciseId, null, mus.Weight, mus.Name)) ?? [];

        await connection.ExecuteAsync(ExerciseDataAccess.InsertExerciseMuscles, exerciseMuscleEntities);
        return await GetExerciseByIdAsync(exerciseId, userId);
    }

    public async Task<Exercise> UpdateExerciseAsync(Exercise exercise, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var updateEntity = new ExerciseEntity(
            exercise.Id,
            (exercise.Name ?? ""),
            exercise.Instructions,
            (exercise.Category ?? ""),
            (exercise.Equipment ?? ""),
            userId);

        await connection.ExecuteAsync(ExerciseDataAccess.UpdateExerciseWithDetails, updateEntity);

        await connection.ExecuteAsync(ExerciseDataAccess.DeleteExerciseMusclesByExerciseId, new { ExerciseId = exercise.Id });

        var exerciseMuscleEntities = exercise.Muscles?
            .Select(mus => new ExerciseMuscleEntity(null, exercise.Id, null, mus.Weight, mus.Name)) ?? [];

        await connection.ExecuteAsync(ExerciseDataAccess.InsertExerciseMuscles, exerciseMuscleEntities);

        return await GetExerciseByIdAsync(exercise.Id, userId);
    }

    public async Task DeleteExerciseByIdAsync(int id, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(ExerciseDataAccess.DeleteExerciseById, new { id, userId });
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
