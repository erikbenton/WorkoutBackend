using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.CompletedWorkouts;

public interface ICompletedWorkoutRepository
{
    public Task<IEnumerable<CompletedWorkoutSummaryEntity>> GetCompletedWorkoutSummariesAsync(string userId);
    public Task<IEnumerable<CompletedWorkoutEntity>> GetAllCompletedWorkoutEntitiesAsync(string userId);
    public Task<CompletedWorkoutEntity> GetCompletedWorkoutEntityByIdAsync(int id, string userId);
    public Task<CompletedWorkoutEntity> CreateCompletedWorkoutEntityAsync(CompletedWorkoutEntity workout);
    public Task<CompletedWorkoutEntity> UpdateCompletedWorkoutEntityAsync(CompletedWorkoutEntity workout);
    public Task DeleteCompletedWorkoutEntityAsync(int id, string userId);
}
