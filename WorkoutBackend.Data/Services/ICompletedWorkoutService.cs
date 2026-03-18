using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Services;

public interface ICompletedWorkoutService
{
    public Task<IEnumerable<CompletedWorkout>> GetAllCompletedWorkoutsPopulatedAsync(string userId);

    public Task<CompletedWorkout> GetCompletedWorkoutByIdAsync(int id, string userId);

    public Task<IEnumerable<CompletedExerciseGroupHistory>> GetCompletedGroupHistoryByExerciseAsync(int exerciseId, string userId);

    public Task<CompletedWorkout> SaveCompletedWorkoutAsync(CompletedWorkout completedWorkout, string userId);

    public Task DeleteCompletedWorkoutAsync(int id, string userId);
}
