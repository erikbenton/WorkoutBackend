using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.CompletedWorkouts;

public interface ICompletedExerciseGroupRepository
{
    public Task<IEnumerable<CompletedExerciseGroupEntity>> GetAllCompletedExerciseGroupEntitiesForCompletedWorkoutAsync(int completedWorkoutId);
    public Task<CompletedExerciseGroupEntity> GetCompletedExerciseGroupEntityByIdAsync(int id);
    public Task<IEnumerable<CompletedExerciseGroupHistoryEntity>> GetCompletedGroupHistoryByExerciseIdAsync(int exerciseId);
    public Task<CompletedExerciseGroupEntity> CreateCompletedExerciseGroupEntityAsync(CompletedExerciseGroupEntity exerciseGroup);
    public Task<CompletedExerciseGroupEntity> UpdateCompletedExerciseGroupEntityAsync(CompletedExerciseGroupEntity exerciseGroup);
    public Task DeleteCompletedExerciseGroupEntityByIdAsync(int id);
}
