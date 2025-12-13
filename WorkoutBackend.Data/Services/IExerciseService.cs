using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Services;

public interface IExerciseService
{
    public Task<IEnumerable<Exercise>> GetAllExercisesAsync();
    public Task<Exercise> GetExerciseByIdAsync(int id);
    public Task<IEnumerable<Exercise>> GetExercisesByNameAsync(string name);
    public Task<Exercise> SaveExerciseAsync(Exercise exercise);
    public Task DeleteExerciseAsync(int id);
    public Task<IEnumerable<BodyPartOption>> GetExerciseBodyPartOptionsAsync();
    public Task<IEnumerable<EquipmentOption>> GetExerciseEquipmentOptionsAsync();
}
