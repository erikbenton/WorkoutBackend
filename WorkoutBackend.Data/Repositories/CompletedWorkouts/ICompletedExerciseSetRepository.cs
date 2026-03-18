using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.CompletedWorkouts;

public interface ICompletedExerciseSetRepository
{
    public Task<IEnumerable<CompletedExerciseSetEntity>> GetAllCompletedExerciseSetEntitiesForCompletedGroupAsync(int completedExerciseGroupId, string userId);

    public Task<CompletedExerciseSetEntity> GetCompletedExerciseSetEntityByIdAsync(int id, string userId);

    public Task<CompletedExerciseSetEntity> CreateCompletedExerciseSetEntityAsync(CompletedExerciseSetEntity exerciseSet);

    public Task<CompletedExerciseSetEntity> UpdateCompletedExerciseSetEntityAsync(CompletedExerciseSetEntity exerciseSet);

    public Task DeleteCompletedExerciseSetEntityByIdAsync(int id, string userId);
}
