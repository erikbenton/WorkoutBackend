using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Services;

public interface IWorkoutRetriever
{
    public Task<Workout> RetrieveFullyPopulatedWorkoutAsync(int workoutId);

    public Task<IEnumerable<Workout>> RetrieveAllWorkoutsList();

    public Task<IEnumerable<ExerciseGroup>> RetrieveAllExerciseGroupsForWorkoutAsync(int workoutId);

    public Task<IEnumerable<ExerciseSet>> RetrieveAllExerciseSetsForExerciseGroupIdAsync(int groupId);
}