using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.CompletedWorkouts;

public interface ICompletedExerciseGroupRepository
{
    public Task<IEnumerable<CompletedExerciseGroupEntity>> GetAllCompletedExerciseGroupEntitiesForCompletedWorkoutAsync(int completedWorkoutId, string userId);
    public Task<CompletedExerciseGroupEntity> GetCompletedExerciseGroupEntityByIdAsync(int id, string userId);
    public Task<IEnumerable<CompletedExerciseGroupHistoryEntity>> GetCompletedGroupHistoryByExerciseIdAsync(int exerciseId, string userId);
    public Task<CompletedExerciseGroupEntity> CreateCompletedExerciseGroupEntityAsync(CompletedExerciseGroupEntity exerciseGroup);
    public Task<CompletedExerciseGroupEntity> UpdateCompletedExerciseGroupEntityAsync(CompletedExerciseGroupEntity exerciseGroup);
    public Task DeleteCompletedExerciseGroupEntityByIdAsync(int id, string userId);
    public Task<IEnumerable<CompletedExerciseGroup>> GetAllCompletedGroupsPopulatedAsync(string userId);
}
