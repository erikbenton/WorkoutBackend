using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Workouts;

public class SqlExerciseGroupRepository(string connectionString) : IExerciseGroupRepository
{
    private readonly string _connectionString = connectionString;
    public async Task<ExerciseGroupEntity> CreateExerciseGroupEntityAsync(ExerciseGroupEntity exerciseGroup)
    {
        using var connection = new SqlConnection(_connectionString);
        var savedGroup = await connection.QueryFirstAsync<ExerciseGroupEntity>(ExerciseGroupDataAccess.InsertExerciseGroup, exerciseGroup);
        return savedGroup;
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
        var updatedGroup = await connection.QueryFirstAsync<ExerciseGroupEntity>(ExerciseGroupDataAccess.UpdateExerciseGroupById, exerciseGroup);
        return updatedGroup;
    }

    public async Task<IEnumerable<ExerciseGroup>> GetAllExerciseGroupsPopulatedAsync()
    {
        using var connection = new SqlConnection(_connectionString);

        List<ExerciseGroup> exerciseGroups = new();

        var results = await connection.QueryMultipleAsync(ExerciseGroupDataAccess.GetAllExerciseGroups);

        var groups = results.Read<ExerciseGroupEntity>();
        var sets = results.Read<ExerciseSetEntity>();

        foreach (var group in groups)
        {
            TimeSpan? restTime = group.RestTimeInSeconds is not null
                ? TimeSpan.FromSeconds((long)group.RestTimeInSeconds)
                : null;

            var exerciseGroup = new ExerciseGroup()
            {
                Id = group.Id,
                Sort = group.Sort,
                ExerciseId = group.ExerciseId,
                Note = group.Note,
                RestTime = restTime,
                WorkoutId = group.WorkoutId,
            };

            var exerciseSets = sets
                .Where(s => s.ExerciseGroupId == group.Id)
                .Select(s => new ExerciseSet()
                {
                    Id = s.Id,
                    MinReps = s.MinReps,
                    MaxReps = s.MaxReps,
                    SetType = s.SetType,
                    Sort = s.Sort,
                    ExerciseGroupId = group.Id
                })
                .OrderBy(s => s.Sort);

            exerciseGroup.ExerciseSets = exerciseSets;
            exerciseGroups.Add(exerciseGroup);
        }

        return exerciseGroups;
    }
}
