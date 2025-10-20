using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Repositories;

namespace WorkoutBackend.Data.Services;

public class SqlWorkoutRetriever(
    IWorkoutRepository workoutRepository,
    IExerciseGroupRepository exerciseGroupRepository,
    IExerciseSetRepository exerciseSetRepository,
    IExerciseRepository exerciseRepository) : IWorkoutRetriever
{
    private readonly IWorkoutRepository _workoutRepository = workoutRepository;
    private readonly IExerciseGroupRepository _exerciseGroupRepository = exerciseGroupRepository;
    private readonly IExerciseSetRepository _exerciseSetRepository = exerciseSetRepository;
    private readonly IExerciseRepository _exerciseRepository = exerciseRepository;

    public async Task<Workout> RetrieveFullyPopulatedWorkoutAsync(int workoutId)
    {
        // Get the main data for the workout
        var workout = await _workoutRepository.GetWorkoutByIdAsync(workoutId);

        // get the exercise groups for the workout
        var groups = await RetrieveAllExerciseGroupsForWorkoutAsync(workout.Id);

        // Convert them to a list for indexing
        var exerciseGroups = groups.ToList();

        // Retrieve all of the sets and exercises
        for (int i = 0; i < exerciseGroups.Count; i++)
        {
            exerciseGroups[i].ExerciseSets = await RetrieveAllExerciseSetsForExerciseGroupIdAsync(exerciseGroups[i].Id);

            exerciseGroups[i].Exercise = await _exerciseRepository
                .GetExerciseByIdAsync(exerciseGroups[i].Exercise.Id);
        }

        workout.ExerciseGroups = exerciseGroups;

        return workout;
    }

    public async Task<IEnumerable<ExerciseGroup>> RetrieveAllExerciseGroupsForWorkoutAsync(int workoutId)
    {
        var groups = await _exerciseGroupRepository.GetAllExerciseGroupEntitiesForWorkoutAsync(workoutId);

        return groups.Select(group =>
        {
            return new ExerciseGroup()
            {
                Id = group.Id,
                Note = group.Note,
                Sort = group.Sort,
                Exercise = new Exercise()
                {
                    Id = group.ExerciseId
                },
                WorkoutId = group.WorkoutId,
            };
        });
    }

    public async Task<IEnumerable<ExerciseSet>> RetrieveAllExerciseSetsForExerciseGroupIdAsync(int groupId)
    {
        var sets = await _exerciseSetRepository.GetAllExerciseSetEntitiesForExerciseGroupAsync(groupId);

        return sets.Select(set =>
        {
            return new ExerciseSet()
            {
                Id = set.Id,
                MinReps = set.MinReps,
                MaxReps = set.MaxReps,
                Weight = set.Weight,
                Sort = set.Sort,
                ExerciseGroupId = set.ExerciseGroupId,
            };
        });
    }

    public async Task<IEnumerable<Workout>> RetrieveAllWorkoutsList()
    {
        var workouts = await _workoutRepository.GetAllWorkoutEntitiesAsync();

        return workouts.Select(workout =>
        {
            return new Workout()
            {
                Id = workout.Id,
                Name = workout.Name,
                WorkoutProgramId = workout.ProgramId,
            };
        });
    }
}
