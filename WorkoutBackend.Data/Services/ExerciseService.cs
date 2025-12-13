using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Repositories.Exercises;

namespace WorkoutBackend.Data.Services;

public class ExerciseService(IExerciseRepository exerciseRepository) : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository = exerciseRepository;

    public async Task DeleteExerciseAsync(int id)
    {
        await _exerciseRepository.DeleteExerciseByIdAsync(id);
    }

    public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
    {
        return await _exerciseRepository.GetAllExercisesAsync();
    }

    public async Task<IEnumerable<BodyPartOption>> GetExerciseBodyPartOptionsAsync()
    {
        return await _exerciseRepository.GetAllBodyPartOptionsAsync();
    }

    public async Task<Exercise> GetExerciseByIdAsync(int id)
    {
        return await _exerciseRepository.GetExerciseByIdAsync(id);
    }

    public async Task<IEnumerable<Exercise>> GetExercisesByNameAsync(string name)
    {
        return await _exerciseRepository.GetExercisesByNameAsync(name);
    }

    public async Task<IEnumerable<EquipmentOption>> GetExerciseEquipmentOptionsAsync()
    {
        return await _exerciseRepository.GetAllEquipmentOptionsAsync();
    }

    public async Task<Exercise> SaveExerciseAsync(Exercise exercise)
    {
        if (string.IsNullOrEmpty(exercise.Name))
        {
            throw new ArgumentNullException("Exercise name was null/empty.");
        }

        return exercise.Id == 0
            ? await _exerciseRepository.CreateExerciseAsync(exercise)
            : await _exerciseRepository.UpdateExerciseAsync(exercise);
    }
}