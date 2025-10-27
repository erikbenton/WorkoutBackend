using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.CompletedWorkouts;

public interface ICompletedWorkoutRepository
{
    public Task<IEnumerable<CompletedWorkoutEntity>> GetAllCompletedWorkoutEntitiesAsync();
    public Task<CompletedWorkoutEntity> GetCompletedWorkoutEntityByIdAsync(int id);
    public Task<CompletedWorkoutEntity> CreateCompletedWorkoutEntityAsync(CompletedWorkoutEntity workout);
    public Task<CompletedWorkoutEntity> UpdateCompletedWorkoutEntityAsync(CompletedWorkoutEntity workout);
    public Task DeleteCompletedWorkoutEntityAsync(int id);
}
