using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.CompletedWorkouts;

public interface ICompletedExerciseSetRepository
{
    public Task<IEnumerable<CompletedExerciseSetEntity>> GetAllCompletedExerciseSetEntitiesForCompletedGroupAsync(int completedExerciseGroupId);

    public Task<CompletedExerciseSetEntity> GetCompletedExerciseSetEntityByIdAsync(int id);

    public Task<CompletedExerciseSetEntity> CreateCompletedExerciseSetEntityAsync(CompletedExerciseSetEntity exerciseSet);

    public Task<CompletedExerciseSetEntity> UpdateCompletedExerciseSetEntityAsync(CompletedExerciseSetEntity exerciseSet);

    public Task DeleteCompletedExerciseSetEntityByIdAsync(int id);
}
