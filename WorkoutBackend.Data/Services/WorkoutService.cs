using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Entities;
using WorkoutBackend.Data.Repositories.Exercises;
using WorkoutBackend.Data.Repositories.Workouts;

namespace WorkoutBackend.Data.Services;

public class WorkoutService(
    IWorkoutRepository workoutRepository,
    IExerciseGroupRepository exerciseGroupRepository,
    IExerciseSetRepository exerciseSetRepository) : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository = workoutRepository;
    private readonly IExerciseGroupRepository _exerciseGroupRepository = exerciseGroupRepository;
    private readonly IExerciseSetRepository _exerciseSetRepository = exerciseSetRepository;

    public async Task<Workout> RetrieveFullyPopulatedWorkoutAsync(int workoutId, string userId)
    {
        // Get the main data for the workout
        var workoutEntity = await _workoutRepository.GetWorkoutEntityByIdAsync(workoutId, userId);

        var workout = new Workout()
        {
            Id = workoutEntity.Id,
            Name = workoutEntity.Name,
            Description = workoutEntity.Description,
        };

        // get the exercise groups for the workout
        var groups = await RetrieveAllExerciseGroupsForWorkoutAsync(workout.Id, userId);

        // Convert them to a list for indexing
        var exerciseGroups = groups.ToList();

        // Retrieve all of the sets and exercises
        for (int i = 0; i < exerciseGroups.Count; i++)
        {
            exerciseGroups[i].ExerciseSets = await RetrieveAllExerciseSetsForExerciseGroupIdAsync(exerciseGroups[i].Id, userId);

            exerciseGroups[i].ExerciseId = exerciseGroups[i].ExerciseId;
        }

        workout.ExerciseGroups = exerciseGroups;

        return workout;
    }

    public async Task<IEnumerable<ExerciseGroup>> RetrieveAllExerciseGroupsForWorkoutAsync(int workoutId, string userId)
    {
        var groups = await _exerciseGroupRepository.GetAllExerciseGroupEntitiesForWorkoutAsync(workoutId, userId);

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
                ExerciseId = group.ExerciseId,
                WorkoutId = group.WorkoutId,
            };
        });
    }

    public async Task<IEnumerable<ExerciseSet>> RetrieveAllExerciseSetsForExerciseGroupIdAsync(int groupId, string userId)
    {
        var sets = await _exerciseSetRepository.GetAllExerciseSetEntitiesForExerciseGroupAsync(groupId, userId);

        return sets.Select(set =>
        {
            return new ExerciseSet()
            {
                Id = set.Id,
                MinReps = set.MinReps,
                MaxReps = set.MaxReps,
                SetTagId = set.SetTagId,
                Sort = set.Sort,
                ExerciseGroupId = set.ExerciseGroupId,
            };
        });
    }

    public async Task<Workout> SaveWorkoutAsync(Workout workout, string userId)
    {
        var workoutEntityToSave = new WorkoutEntity(
            workout.Id,
            workout.Name.Trim(),
            workout.Description?.Trim(),
            workout.WorkoutProgramId,
            userId);

        // save the workout to ensure correct Id
        var savedDbWorkout = workout.Id == 0
            ? await _workoutRepository.CreateWorkoutEntityAsync(workoutEntityToSave)
            : await _workoutRepository.UpdateWorkoutEntityAsync(workoutEntityToSave);

        // update the fields with the saved entity
        workout.Id = savedDbWorkout.Id;
        workout.Name = savedDbWorkout.Name;
        workout.Description = savedDbWorkout.Description;
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
        workout.ExerciseGroups = await SaveAWorkoutsExerciseGroupsAsync(workout, userId);

        // need to iterate over the Exercise Groups to save their Exercise Sets
        // (async code does not play nice with foreach)
        var exerciseGroupsWithSetsToSave = workout.ExerciseGroups.ToArray();

        for (int i = 0; i < exerciseGroupsWithSetsToSave.Length; i++)
        {
            // Save each group's Exercise Sets
            exerciseGroupsWithSetsToSave[i].ExerciseSets = await SaveAnExerciseGroupsExerciseSetsAsync(exerciseGroupsWithSetsToSave[i], userId);
        }

        // reassign the exercise groups iterated over back to the workout
        workout.ExerciseGroups = exerciseGroupsWithSetsToSave;

        return workout;
    }

    public async Task<ExerciseGroup> SaveExerciseGroupAsync(ExerciseGroup exerciseGroup, string userId)
    {
        var exerciseGroupEntity = new ExerciseGroupEntity(exerciseGroup.Id,
            exerciseGroup.Note?.Trim(),
            (int?)exerciseGroup.RestTime?.TotalSeconds,
            exerciseGroup.Sort,
            exerciseGroup.ExerciseId,
            exerciseGroup.WorkoutId,
            userId);

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

    public async Task<IEnumerable<ExerciseGroup>> SaveAWorkoutsExerciseGroupsAsync(Workout workout, string userId)
    {
        // Get all of the already saved Exercise Groups for the workout
        var exerciseGroupsInDb = await _exerciseGroupRepository.GetAllExerciseGroupEntitiesForWorkoutAsync(workout.Id, userId);

        // Find which Exercise Group entities are no longer in the workout
        var dbGroupIds = exerciseGroupsInDb.Select(group => group.Id);
        var workoutGroupIds = workout.ExerciseGroups.Select(group => group.Id);
        var dbOnlyIds = dbGroupIds.Except(workoutGroupIds).ToArray();

        // Delete the entities which are no longer in the workout
        for (int i = 0; i < dbOnlyIds.Length; i++)
        {
            await _exerciseGroupRepository.DeleteExerciseGroupEntityByIdAsync(dbOnlyIds[i], userId);
        }

        // Need to iterate through the groups
        var exerciseGroups = workout.ExerciseGroups.ToArray();

        // Save the Exercise Groups in the given workout
        for (int i = 0; i < exerciseGroups.Length; i++)
        {
            exerciseGroups[i] = await SaveExerciseGroupAsync(exerciseGroups[i], userId);
        }

        return exerciseGroups;
    }

    public async Task<IEnumerable<ExerciseSet>> SaveAnExerciseGroupsExerciseSetsAsync(ExerciseGroup exerciseGroup, string userId)
    {
        // Get all of the already existing Exercise Sets
        var setsInDb = await _exerciseSetRepository.GetAllExerciseSetEntitiesForExerciseGroupAsync(exerciseGroup.Id, userId);

        // Find which exercise sets are no longer in the exercise group to save
        var groupSetIds = exerciseGroup.ExerciseSets.Select(set => set.Id);
        var dbSetIds = setsInDb.Select(set => set.Id);
        var dbOnlyIds = dbSetIds.Except(groupSetIds).ToArray();

        // delete the sets only in the DB
        for (int i = 0; i < dbOnlyIds.Length; i++)
        {
            await _exerciseSetRepository.DeleteExerciseSetEntityByIdAsync(dbOnlyIds[i], userId);
        }

        // Need to iterate over the exercise sets
        var exerciseSets = exerciseGroup.ExerciseSets.ToArray();

        // Save the exercise sets in the exercise group
        for (int i = 0; i < exerciseSets.Length; i++)
        {
            exerciseSets[i] = await SaveExerciseSetAsync(exerciseSets[i], userId);
        }

        return exerciseSets;
    }

    public async Task<ExerciseSet> SaveExerciseSetAsync(ExerciseSet exerciseSet, string userId)
    {
        var dbSet = new ExerciseSetEntity(
            exerciseSet.Id,
            exerciseSet.MinReps,
            exerciseSet.MaxReps,
            exerciseSet.SetTagId,
            exerciseSet.Sort,
            exerciseSet.ExerciseGroupId,
            userId);

        // if the exercise set hasn't been saved already
        var set = exerciseSet.Id == 0
            ? await _exerciseSetRepository.CreateExerciseSetEntityAsync(dbSet)
            : await _exerciseSetRepository.UpdateExerciseSetEntityAsync(dbSet);

        exerciseSet.Id = dbSet.Id;
        exerciseSet.MinReps = dbSet.MinReps;
        exerciseSet.MaxReps = dbSet.MaxReps;
        exerciseSet.SetTagId = dbSet.SetTagId;
        exerciseSet.Sort = dbSet.Sort;
        exerciseSet.ExerciseGroupId = dbSet.ExerciseGroupId;

        return exerciseSet;
    }

    public async Task DeleteWorkoutByIdAsync(int workoutId, string userId)
    {
        await _workoutRepository.DeleteWorkoutEntityAsync(workoutId, userId);
    }

    public async Task<IEnumerable<Workout>> RetrieveAllWorkoutsAsync(string userId)
    {
        var workoutEntities = await _workoutRepository.GetAllWorkoutEntitiesAsync(userId);

        var workouts = workoutEntities.Select(w => new Workout()
        {
            Id = w.Id,
            Name = w.Name,
            Description = w.Description,
            WorkoutProgramId = w.ProgramId,
            ExerciseGroups = []
        }).ToList(); // needs to be a list for the loop

        var exerciseGroups = await _exerciseGroupRepository.GetAllExerciseGroupsPopulatedAsync(userId);

        foreach (var workout in workouts)
        {
            IEnumerable<ExerciseGroup> groups = exerciseGroups != null
                ? exerciseGroups.Where(g => g.WorkoutId == workout.Id).OrderBy(g => g.Sort)
                : [];

            workout.ExerciseGroups = groups;
        }

        return workouts;
    }

    public async Task<IEnumerable<SetTagOption>> GetSetTagOptionsAsync()
    {
        var setTagOptions = await _workoutRepository.GetAllSetTagOptionsAsync();
        return setTagOptions;
    }
}
