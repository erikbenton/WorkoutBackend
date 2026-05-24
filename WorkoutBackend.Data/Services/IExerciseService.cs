using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Services;

public interface IExerciseService
{
    public Task<IEnumerable<Exercise>> GetAllExercisesAsync(string? userId = null);
    public Task<Exercise> GetExerciseByIdAsync(int id, string? userId = null);
    public Task<IEnumerable<Exercise>> GetExercisesByNameAsync(string name, string? userId = null);
    public Task<Exercise> SaveExerciseAsync(Exercise exercise, string userId);
    public Task DeleteExerciseAsync(int id, string userId);
    public Task<IEnumerable<MuscleOption>> GetExerciseMuscleOptionsAsync();
    public Task<IEnumerable<EquipmentOption>> GetExerciseEquipmentOptionsAsync();
}
