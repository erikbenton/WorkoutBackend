using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Repositories.Exercises;

public interface IExerciseRepository
{
    public Task<IEnumerable<Exercise>> GetAllExercisesAsync(string? userId = null);

    public Task<Exercise> GetExerciseByIdAsync(int id, string? userId = null);

    public Task<IEnumerable<Exercise>> GetExercisesByNameAsync(string name, string? userId = null);

    public Task<Exercise> UpdateExerciseAsync(Exercise exercise, string userId);

    public Task<Exercise> CreateExerciseAsync(Exercise exercise, string userId);

    public Task DeleteExerciseByIdAsync(int id, string userId);

    public Task<IEnumerable<MuscleOption>> GetAllMuscleOptionsAsync();

    public Task<IEnumerable<EquipmentOption>> GetAllEquipmentOptionsAsync();
}
