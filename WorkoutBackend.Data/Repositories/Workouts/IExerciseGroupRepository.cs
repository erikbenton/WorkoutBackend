using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Workouts;

public interface IExerciseGroupRepository
{
    public Task<IEnumerable<ExerciseGroupEntity>> GetAllExerciseGroupEntitiesForWorkoutAsync(int workoutId, string userId);
    public Task<ExerciseGroupEntity> GetExerciseGroupByIdAsync(int id, string userId);
    public Task<ExerciseGroupEntity> CreateExerciseGroupEntityAsync(ExerciseGroupEntity exerciseGroup);
    public Task<ExerciseGroupEntity> UpdateExerciseGroupEntityAsync(ExerciseGroupEntity exerciseGroup);
    public Task DeleteExerciseGroupEntityByIdAsync(int id, string userId);

    public Task<IEnumerable<ExerciseGroup>> GetAllExerciseGroupsPopulatedAsync(string userId);
}
