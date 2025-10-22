using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Services;

public interface IWorkoutService
{
    public Task<Workout> RetrieveFullyPopulatedWorkoutAsync(int workoutId);

    public Task<IEnumerable<Workout>> RetrieveAllWorkoutsList();

    public Task<IEnumerable<ExerciseGroup>> RetrieveAllExerciseGroupsForWorkoutAsync(int workoutId);

    public Task<IEnumerable<ExerciseSet>> RetrieveAllExerciseSetsForExerciseGroupIdAsync(int groupId);

    public Task<Workout> SaveWorkoutAsync(Workout workout);

    public Task<IEnumerable<ExerciseGroup>> SaveAWorkoutsExerciseGroupsAsync(Workout workout);

    public Task<ExerciseGroup> SaveExerciseGroupAsync(ExerciseGroup exerciseGroup);

    public Task<IEnumerable<ExerciseSet>> SaveAnExerciseGroupsExerciseSetsAsync(ExerciseGroup exerciseGroup);

    public Task<ExerciseSet> SaveExerciseSetAsync(ExerciseSet exerciseSet);

    public Task DeleteWorkoutByIdAsync(int workoutId);
}
