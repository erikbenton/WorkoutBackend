using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Services;

public interface IWorkoutService
{
    public Task<Workout> RetrieveFullyPopulatedWorkoutAsync(int workoutId, string userId);
    public Task<IEnumerable<SetTagOption>> GetSetTagOptionsAsync();
    public Task<IEnumerable<Workout>> RetrieveAllWorkoutsAsync(string userId);
    public Task<Workout> SaveWorkoutAsync(Workout workout, string userId);
    public Task DeleteWorkoutByIdAsync(int workoutId, string userId);
}
