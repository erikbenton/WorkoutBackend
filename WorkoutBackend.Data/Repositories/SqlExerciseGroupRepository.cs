﻿using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories;

public class SqlExerciseGroupRepository(string connectionString) : IExerciseGroupRepository
{
    private readonly string _connectionString = connectionString;
    public async Task<ExerciseGroupEntity> CreateExerciseGroupEntityAsync(ExerciseGroupEntity exerciseGroup)
    {
        using var connection = new SqlConnection(_connectionString);
        var savedId = await connection.QueryFirstAsync<int>(ExerciseGroupDataAccess.InsertExerciseGroup, exerciseGroup);
        return await GetExerciseGroupByIdAsync(savedId);
    }

    public async Task DeleteExerciseGroupEntityByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(ExerciseGroupDataAccess.DeleteExerciseGroupById, new { id });
    }

    public async Task<ExerciseGroupEntity> GetExerciseGroupByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var exerciseGroup = await connection.QueryFirstAsync<ExerciseGroupEntity>(ExerciseGroupDataAccess.GetExerciseGroupById, new { id });
        return exerciseGroup;
    }

    public async Task<IEnumerable<ExerciseGroupEntity>> GetAllExerciseGroupEntitiesForWorkoutAsync(int workoutId)
    {
        using var connection = new SqlConnection(_connectionString);
        var exerciseGroups = await connection.QueryAsync<ExerciseGroupEntity>(ExerciseGroupDataAccess.GetExerciseGroupsByWorkoutId, new { workoutId });
        return exerciseGroups;
    }

    public async Task<ExerciseGroupEntity> UpdateExerciseGroupEntityAsync(ExerciseGroupEntity exerciseGroup)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(ExerciseGroupDataAccess.UpdateExerciseGroupById, exerciseGroup);
        return await GetExerciseGroupByIdAsync(exerciseGroup.Id);
    }
}
