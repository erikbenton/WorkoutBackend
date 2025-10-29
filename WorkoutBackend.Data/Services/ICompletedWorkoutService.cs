using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Services;

public interface ICompletedWorkoutService
{
    public Task<IEnumerable<CompletedWorkoutSummary>> GetAllCompletedWorkoutSummariesAsync();

    public Task<CompletedWorkout> GetCompletedWorkoutByIdAsync(int id);

    public Task<CompletedWorkout> SaveCompletedWorkoutAsync(CompletedWorkout completedWorkout);

    public Task DeleteCompletedWorkoutAsync(int id);
}
