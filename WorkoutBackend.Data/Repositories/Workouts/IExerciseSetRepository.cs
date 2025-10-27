using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Workouts;

public interface IExerciseSetRepository
{
    public Task<IEnumerable<ExerciseSetEntity>> GetAllExerciseSetEntitiesForExerciseGroupAsync(int exerciseGroupId);

    public Task<ExerciseSetEntity> GetExerciseSetEntityByIdAsync(int id);

    public Task<ExerciseSetEntity> CreateExerciseSetEntityAsync(ExerciseSetEntity exerciseSet);

    public Task<ExerciseSetEntity> UpdateExerciseSetEntityAsync(ExerciseSetEntity exerciseSet);

    public Task DeleteExerciseSetEntityByIdAsync(int id);
}
