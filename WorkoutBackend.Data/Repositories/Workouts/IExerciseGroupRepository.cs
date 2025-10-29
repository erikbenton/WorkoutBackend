using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Workouts;

public interface IExerciseGroupRepository
{
    public Task<IEnumerable<ExerciseGroupEntity>> GetAllExerciseGroupEntitiesForWorkoutAsync(int workoutId);
    public Task<ExerciseGroupEntity> GetExerciseGroupByIdAsync(int id);
    public Task<ExerciseGroupEntity> CreateExerciseGroupEntityAsync(ExerciseGroupEntity exerciseGroup);
    public Task<ExerciseGroupEntity> UpdateExerciseGroupEntityAsync(ExerciseGroupEntity exerciseGroup);
    public Task DeleteExerciseGroupEntityByIdAsync(int id);
}
