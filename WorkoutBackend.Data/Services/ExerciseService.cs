using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Repositories.Exercises;

namespace WorkoutBackend.Data.Services;

public class ExerciseService(IExerciseRepository exerciseRepository) : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository = exerciseRepository;

    public async Task DeleteExerciseAsync(int id, string userId)
    {
        await _exerciseRepository.DeleteExerciseByIdAsync(id, userId);
    }

    public async Task<IEnumerable<Exercise>> GetAllExercisesAsync(string? userId = null)
    {
        return await _exerciseRepository.GetAllExercisesAsync(userId);
    }

    public async Task<IEnumerable<MuscleOption>> GetExerciseMuscleOptionsAsync()
    {
        return await _exerciseRepository.GetAllMuscleOptionsAsync();
    }

    public async Task<Exercise> GetExerciseByIdAsync(int id, string? userId = null)
    {
        return await _exerciseRepository.GetExerciseByIdAsync(id, userId);
    }

    public async Task<IEnumerable<Exercise>> GetExercisesByNameAsync(string name, string? userId = null)
    {
        return await _exerciseRepository.GetExercisesByNameAsync(name, userId);
    }

    public async Task<IEnumerable<EquipmentOption>> GetExerciseEquipmentOptionsAsync()
    {
        return await _exerciseRepository.GetAllEquipmentOptionsAsync();
    }

    public async Task<Exercise> SaveExerciseAsync(Exercise exercise, string userId)
    {
        if (string.IsNullOrEmpty(exercise.Name))
        {
            throw new ArgumentNullException("Exercise name was null/empty.");
        }

        return exercise.Id == 0
            ? await _exerciseRepository.CreateExerciseAsync(exercise, userId)
            : await _exerciseRepository.UpdateExerciseAsync(exercise, userId);
    }
}