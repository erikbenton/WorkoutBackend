using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Repositories;

public interface IExerciseRepository
{
    public Task<IEnumerable<Exercise>> GetAllExercisesAsync();

    public Task<Exercise> GetExerciseByIdAsync(int id);

    public Task<IEnumerable<Exercise>> GetExercisesByNameAsync(string name);

    public Task<Exercise> UpdateExerciseAsync(Exercise exercise);

    public Task<Exercise> CreateExercise(Exercise exercise);

    public Task DeleteExerciseByIdAsync(int id);

    public Task<IEnumerable<BodyPartOption>> GetAllBodyPartOptionsAsync();

    public Task<IEnumerable<EquipmentOption>> GetAllEquipmentOptionsAsync();
}
