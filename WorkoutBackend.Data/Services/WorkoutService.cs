using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Entities;
using WorkoutBackend.Data.Repositories.Exercises;
using WorkoutBackend.Data.Repositories.Workouts;

namespace WorkoutBackend.Data.Services;

public class WorkoutService(
    IWorkoutRepository workoutRepository,
    IExerciseGroupRepository exerciseGroupRepository,
    IExerciseSetRepository exerciseSetRepository,
    IExerciseRepository exerciseRepository) : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository = workoutRepository;
    private readonly IExerciseGroupRepository _exerciseGroupRepository = exerciseGroupRepository;
    private readonly IExerciseSetRepository _exerciseSetRepository = exerciseSetRepository;
    private readonly IExerciseRepository _exerciseRepository = exerciseRepository;

    public async Task<Workout> RetrieveFullyPopulatedWorkoutAsync(int workoutId)
    {
        // Get the main data for the workout
        var workoutEntity = await _workoutRepository.GetWorkoutEntityByIdAsync(workoutId);

        var workout = new Workout()
        {
            Id = workoutEntity.Id,
            Name = workoutEntity.Name,
        };

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
            TimeSpan? restTime = group.RestTimeInSeconds is not null
                ? TimeSpan.FromSeconds((long)group.RestTimeInSeconds)
                : null;
            return new ExerciseGroup()
            {
                Id = group.Id,
                Note = group.Note,
                RestTime = restTime,
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

    public async Task<Workout> SaveWorkoutAsync(Workout workout)
    {
        var workoutEntityToSave = new WorkoutEntity(workout.Id, workout.Name, workout.WorkoutProgramId);

        // save the workout to ensure correct Id
        var savedDbWorkout = workout.Id == 0
            ? await _workoutRepository.CreateWorkoutEntityAsync(workoutEntityToSave)
            : await _workoutRepository.UpdateWorkoutEntityAsync(workoutEntityToSave);

        // update the fields with the saved entity
        workout.Id = savedDbWorkout.Id;
        workout.Name = savedDbWorkout.Name;
        workout.WorkoutProgramId = savedDbWorkout.ProgramId;

        // Populate the ExerciseGroups with saved Id and assign Sort
        workout.ExerciseGroups = workout.ExerciseGroups
            .Select((group, index) =>
            {
                group.WorkoutId = savedDbWorkout.Id;
                group.Sort = index;
                return group;
            });

        // save each exercise group in the workout
        workout.ExerciseGroups = await SaveAWorkoutsExerciseGroupsAsync(workout);

        // need to iterate over the Exercise Groups to save their Exercise Sets
        // (async code does not play nice with foreach)
        var exerciseGroupsWithSetsToSave = workout.ExerciseGroups.ToArray();

        for (int i = 0; i < exerciseGroupsWithSetsToSave.Length; i++)
        {
            // Save each group's Exercise Sets
            exerciseGroupsWithSetsToSave[i].ExerciseSets = await SaveAnExerciseGroupsExerciseSetsAsync(exerciseGroupsWithSetsToSave[i]);
        }

        // reassign the exercise groups iterated over back to the workout
        workout.ExerciseGroups = exerciseGroupsWithSetsToSave;

        return workout;
    }

    public async Task<ExerciseGroup> SaveExerciseGroupAsync(ExerciseGroup exerciseGroup)
    {
        var exerciseGroupEntity = new ExerciseGroupEntity(exerciseGroup.Id,
            exerciseGroup.Note,
            (int?)exerciseGroup.RestTime?.TotalSeconds,
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

    public async Task DeleteWorkoutByIdAsync(int workoutId)
    {
        await _workoutRepository.DeleteWorkoutEntityAsync(workoutId);
    }

    public async Task<IEnumerable<WorkoutSummary>> RetrieveAllWorkoutSummariesAsync()
    {
        var workoutSummaryEntries = await _workoutRepository.GetAllWorkoutSummariesEntriesAsync();

        // create a Dictionary in order to aggregate the entries
        // so that the summaries have a collection of the exercise names
        var workoutIdWithSummaries = new Dictionary<int, WorkoutSummary>();

        foreach (var entry in workoutSummaryEntries)
        {
            // if the entry has already been added to the dictionary
            if (workoutIdWithSummaries.ContainsKey(entry.WorkoutId))
            {
                if (entry.ExerciseName is not null)
                {
                    workoutIdWithSummaries[entry.WorkoutId].ExerciseNames.Add(entry.ExerciseName);
                }
            }
            else
            {
                // initiate the new WorkoutSummary
                workoutIdWithSummaries.Add(entry.WorkoutId, new WorkoutSummary()
                {
                    Id = entry.WorkoutId,
                    Name = entry.WorkoutName,
                    ExerciseNames = [entry.ExerciseName]
                });
            }
        }

        // Only need the "Values" from the dictionary
        var workoutSummaries = workoutIdWithSummaries
            .Select(kvp => kvp.Value)
            .OrderBy(summary => summary.Id);

        return workoutSummaries;
    }
}
