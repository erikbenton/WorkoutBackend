using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Services;

public interface IWorkoutSaver
{
    public Task<Workout> SaveWorkoutAsync(Workout workout);

    public Task<IEnumerable<ExerciseGroup>> SaveAWorkoutsExerciseGroupsAsync(Workout workout);

    public Task<ExerciseGroup> SaveExerciseGroupAsync(ExerciseGroup exerciseGroup);

    public Task<IEnumerable<ExerciseSet>> SaveAnExerciseGroupsExerciseSetsAsync(ExerciseGroup exerciseGroup);

    public Task<ExerciseSet> SaveExerciseSetAsync(ExerciseSet exerciseSet);
}
