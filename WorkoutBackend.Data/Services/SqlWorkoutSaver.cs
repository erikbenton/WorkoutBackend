using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Entities;
using WorkoutBackend.Data.Repositories;

namespace WorkoutBackend.Data.Services;

public class SqlWorkoutSaver(
    IWorkoutRepository workoutRepository,
    IExerciseGroupRepository exerciseGroupRepository,
    IExerciseSetRepository exerciseSetRepository) : IWorkoutSaver
{
    private readonly IWorkoutRepository _workoutRepository = workoutRepository;
    private readonly IExerciseGroupRepository _exerciseGroupRepository = exerciseGroupRepository;
    private readonly IExerciseSetRepository _exerciseSetRepository = exerciseSetRepository;

    public async Task<Workout> SaveWorkoutAsync(Workout workout)
    {
        // save the workout to ensure correct Id
        var savedWorkout = await _workoutRepository.SaveWorkoutAsync(workout);

        // save each exercise group in the workout
        savedWorkout.ExerciseGroups = await SaveAWorkoutsExerciseGroupsAsync(workout);

        // need to iterate over the Exercise Groups to save their Exercise Sets
        // (async code does not play nice with foreach)
        var exerciseGroupsWithSetsToSave = savedWorkout.ExerciseGroups.ToArray();

        for (int i = 0; i < exerciseGroupsWithSetsToSave.Length; i++)
        {
            // Save each group's Exercise Sets
            exerciseGroupsWithSetsToSave[i].ExerciseSets = await SaveAnExerciseGroupsExerciseSetsAsync(exerciseGroupsWithSetsToSave[i]);
        }

        // reassign the exercise groups iterated over back to the workout
        savedWorkout.ExerciseGroups = exerciseGroupsWithSetsToSave;

        return savedWorkout;
    }

    public async Task<ExerciseGroup> SaveExerciseGroupAsync(ExerciseGroup exerciseGroup)
    {
        var exerciseGroupEntity = new ExerciseGroupEntity(exerciseGroup.Id,
            exerciseGroup.Note,
            exerciseGroup.Sort,
            exerciseGroup.Exercise.Id,
            exerciseGroup.WorkoutId);

        var savedExerciseGroup = exerciseGroup.Id == 0
            ? await _exerciseGroupRepository.CreateExerciseGroupEntityAsync(exerciseGroupEntity)
            : await _exerciseGroupRepository.UpdateExerciseGroupEntityAsync(exerciseGroupEntity);

        exerciseGroup.Id = savedExerciseGroup.Id;

        // Update the sets with the saved Id and assign their Sort order
        exerciseGroup.ExerciseSets = exerciseGroup.ExerciseSets
            .Select((set, index) =>
            {
                set.ExerciseGroupId = savedExerciseGroup.Id;
                set.Sort = index;
                return set;
            });

        return exerciseGroup;
    }

    public async Task<IEnumerable<ExerciseGroup>> SaveAWorkoutsExerciseGroupsAsync(Workout workout)
    {
        // Get all of the already saved Exercise Groups for the workout
        var exerciseGroupsInDb = await _exerciseGroupRepository.GetAllExerciseGroupEntitiesForWorkoutAsync(workout.Id);

        // Find which Exercise Group entities are no longer in the workout
        var dbGroupIds = exerciseGroupsInDb.Select(group => group.Id);
        var workoutGroupIds = workout.ExerciseGroups.Select(group => group.Id);
        var dbOnlyIds = dbGroupIds.Except(workoutGroupIds).ToArray();

        // Delete the entities which are no longer in the workout
        for (int i = 0; i < dbOnlyIds.Length; i++)
        {
            await _exerciseGroupRepository.DeleteExerciseGroupEntityByIdAsync(dbOnlyIds[i]);
        }

        // Need to iterate through the groups
        var exerciseGroups = workout.ExerciseGroups.ToArray();

        // Save the Exercise Groups in the given workout
        for (int i = 0; i < exerciseGroups.Length; i++)
        {
            exerciseGroups[i] = await SaveExerciseGroupAsync(exerciseGroups[i]);
        }

        return exerciseGroups;
    }

    public async Task<IEnumerable<ExerciseSet>> SaveAnExerciseGroupsExerciseSetsAsync(ExerciseGroup exerciseGroup)
    {
        // Get all of the already existing Exercise Sets
        var setsInDb = await _exerciseSetRepository.GetAllExerciseSetEntitiesForExerciseGroupAsync(exerciseGroup.Id);

        // Find which exercise sets are no longer in the exercise group to save
        var groupSetIds = exerciseGroup.ExerciseSets.Select(set => set.Id);
        var dbSetIds = setsInDb.Select(set => set.Id);
        var dbOnlyIds = dbSetIds.Except(groupSetIds).ToArray();

        // delete the sets only in the DB
        for (int i = 0; i < dbOnlyIds.Length; i++)
        {
            await _exerciseSetRepository.DeleteExerciseSetEntityByIdAsync(dbOnlyIds[i]);
        }

        // Need to iterate over the exercise sets
        var exerciseSets = exerciseGroup.ExerciseSets.ToArray();

        // Save the exercise sets in the exercise group
        for (int i = 0; i < exerciseSets.Length; i++)
        {
            exerciseSets[i] = await SaveExerciseSetAsync(exerciseSets[i]);
        }

        return exerciseSets;
    }

    public async Task<ExerciseSet> SaveExerciseSetAsync(ExerciseSet exerciseSet)
    {
        var dbSet = new ExerciseSetEntity(
            exerciseSet.Id,
            exerciseSet.MinReps,
            exerciseSet.MaxReps,
            exerciseSet.Weight,
            exerciseSet.Sort,
            exerciseSet.ExerciseGroupId);

        // if the exercise set hasn't been saved already
        var set = exerciseSet.Id == 0
            ? await _exerciseSetRepository.CreateExerciseSetEntityAsync(dbSet)
            : await _exerciseSetRepository.UpdateExerciseSetEntityAsync(dbSet);

        exerciseSet.Id = dbSet.Id;
        exerciseSet.MinReps = dbSet.MinReps;
        exerciseSet.MaxReps = dbSet.MaxReps;
        exerciseSet.Weight = dbSet.Weight;
        exerciseSet.Sort = dbSet.Sort;
        exerciseSet.ExerciseGroupId = dbSet.ExerciseGroupId;

        return exerciseSet;
    }
}
