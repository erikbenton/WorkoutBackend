using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Entities;
using WorkoutBackend.Data.Repositories.CompletedWorkouts;
using WorkoutBackend.Data.Repositories.Exercises;

namespace WorkoutBackend.Data.Services;

public class CompletedWorkoutService(
    ICompletedWorkoutRepository completedWorkoutRepository,
    ICompletedExerciseGroupRepository completedExerciseGroupRepository,
    ICompletedExerciseSetRepository completedExerciseSetRepository,
    IExerciseRepository exerciseRepository) : ICompletedWorkoutService
{
    private readonly ICompletedWorkoutRepository _completedWorkoutRepository = completedWorkoutRepository;
    private readonly ICompletedExerciseGroupRepository _completedExerciseGroupRepository = completedExerciseGroupRepository;
    private readonly ICompletedExerciseSetRepository _completedExerciseSetRepository = completedExerciseSetRepository;
    private readonly IExerciseRepository _exerciseRepository = exerciseRepository;

    public async Task DeleteCompletedWorkoutAsync(int id)
    {
        await _completedWorkoutRepository.DeleteCompletedWorkoutEntityAsync(id);
    }

    public async Task<CompletedWorkout> GetCompletedWorkoutByIdAsync(int id)
    {
        // Get the DB completedWorkout
        var dbCompletedWorkout = await _completedWorkoutRepository.GetCompletedWorkoutEntityByIdAsync(id);

        // populate new CompletedWorkout
        var completedWorkout = new CompletedWorkout()
        {
            Id = dbCompletedWorkout.Id,
            WorkoutId = dbCompletedWorkout.WorkoutId,
            Name = dbCompletedWorkout.Name,
            Note = dbCompletedWorkout.Note,
            Duration = TimeSpan.FromSeconds(dbCompletedWorkout.DurationInSeconds),
            CreatedAt = dbCompletedWorkout.CreatedAt,
        };

        // Get the DB Completed Exercise Groups for the CompletedWorkout
        var dbExerciseGroups = await _completedExerciseGroupRepository
            .GetAllCompletedExerciseGroupEntitiesForCompletedWorkoutAsync(completedWorkout.Id);

        // populate the exercise groups
        var unpopulatedGroups = dbExerciseGroups.Select(group =>
        {
            TimeSpan? restTime = group.RestTimeInSeconds is not null
                ? TimeSpan.FromSeconds((long)group.RestTimeInSeconds)
                : null;

            return new CompletedExerciseGroup()
            {
                Id = group.Id,
                Note = group.Note,
                Comment = group.Comment,
                RestTime = restTime,
                Sort = group.Sort,
                Exercise = new Exercise()
                {
                    Id = group.ExerciseId
                },
                CreatedAt = group.CreatedAt,
                CompletedWorkoutId = completedWorkout.Id
            };
        });

        // Make an array to deal with async/indexing
        var exerciseGroups = unpopulatedGroups.ToArray();

        // foreach completed exercise group (async calls inside)
        for (var i = 0; i < exerciseGroups.Length; i++)
        {
            var group = exerciseGroups[i];

            // get their completed exercise sets
            var dbSets = await _completedExerciseSetRepository
                .GetAllCompletedExerciseSetEntitiesForCompletedGroupAsync(group.Id);

            // map the db entity
            group.CompletedExerciseSets = dbSets.Select(set =>
            {
                return new CompletedExerciseSet()
                {
                    Id = set.Id,
                    Reps = set.Reps,
                    Weight = set.Weight,
                    MinReps = set.MinReps,
                    MaxReps = set.MaxReps,
                    SetType = set.SetType,
                    Sort = set.Sort,
                    CreatedAt = set.CreatedAt,
                    CompletedExerciseGroupId = group.Id
                };
            });

            // and their exercises
            group.Exercise = await _exerciseRepository.GetExerciseByIdAsync(group.Exercise.Id);
        }

        // assign the fully populated exercise groups to the workout
        completedWorkout.CompletedExerciseGroups = exerciseGroups;

        return completedWorkout;
    }

    public async Task<CompletedWorkout> SaveCompletedWorkoutAsync(CompletedWorkout completedWorkout)
    {
        var savedCompletedWorkout = new CompletedWorkout();

        // ensure that the duration for DB is not null
        double duration = completedWorkout.Duration?.TotalSeconds ?? 0.0;

        var dbWorkoutToSave = new CompletedWorkoutEntity(
            completedWorkout.Id,
            completedWorkout.WorkoutId,
            completedWorkout.Name.Trim(),
            completedWorkout.Description?.Trim(),
            completedWorkout.Note?.Trim(),
            (int)(duration));

        // Create or Update depending on Id
        var savedWorkoutEntity = dbWorkoutToSave.Id == 0
            ? await _completedWorkoutRepository.CreateCompletedWorkoutEntityAsync(dbWorkoutToSave)
            : await _completedWorkoutRepository.UpdateCompletedWorkoutEntityAsync(dbWorkoutToSave);

        // update the completed workout
        savedCompletedWorkout.Id = savedWorkoutEntity.Id;
        savedCompletedWorkout.WorkoutId = savedWorkoutEntity.WorkoutId;
        savedCompletedWorkout.Name = savedWorkoutEntity.Name;
        savedCompletedWorkout.Description = savedWorkoutEntity.Description;
        savedCompletedWorkout.Note = savedWorkoutEntity.Note;
        savedCompletedWorkout.Duration = TimeSpan.FromSeconds(savedWorkoutEntity.DurationInSeconds);
        savedCompletedWorkout.CreatedAt = savedWorkoutEntity.CreatedAt;

        // update the Sort order for the groups
        completedWorkout.CompletedExerciseGroups = completedWorkout.CompletedExerciseGroups
            .Select((group, index) =>
            {
                group.Sort = index;
                group.CompletedWorkoutId = savedCompletedWorkout.Id;
                return group;
            });

        completedWorkout.CompletedExerciseGroups = await SaveCompletedExerciseGroupsAsync(completedWorkout);

        savedCompletedWorkout.CompletedExerciseGroups = await SaveCompletedExerciseGroupsSetsAsync(completedWorkout.CompletedExerciseGroups);

        return savedCompletedWorkout;
    }

    public async Task<IEnumerable<CompletedWorkoutSummary>> GetAllCompletedWorkoutSummariesAsync()
    {
        var dbWorkoutSummaries = await _completedWorkoutRepository.GetCompletedWorkoutSummariesAsync();
        var workoutSummaries = dbWorkoutSummaries.Select(summary =>
        {
            return new CompletedWorkoutSummary()
            {
                Id = summary.Id,
                Name = summary.Name,
                NumberOfExerciseGroups = summary.NumberOfExerciseGroups,
                Duration = TimeSpan.FromSeconds(summary.DurationInSeconds),
                CompletedAt = summary.CompletedAt
            };
        });

        return workoutSummaries;
    }

    private async Task<IEnumerable<CompletedExerciseGroup>> SaveCompletedExerciseGroupsAsync(CompletedWorkout completedWorkout)
    {
        var exerciseGroupsToSave = completedWorkout.CompletedExerciseGroups.ToArray();

        // for each group, save it to the DB and update the group
        for (int i = 0; i < exerciseGroupsToSave.Length; i++)
        {
            var group = exerciseGroupsToSave[i];

            var dbGroup = new CompletedExerciseGroupEntity(
                group.Id,
                group.Note?.Trim(),
                group.Comment?.Trim(),
                (int?)group.RestTime?.TotalSeconds,
                group.Sort,
                group.Exercise.Id,
                group.CompletedWorkoutId);

            // Create or Update depending on Id
            dbGroup = dbGroup.Id == 0
                ? await _completedExerciseGroupRepository.CreateCompletedExerciseGroupEntityAsync(dbGroup)
                : await _completedExerciseGroupRepository.UpdateCompletedExerciseGroupEntityAsync(dbGroup);

            // update the group with db data
            group.Id = dbGroup.Id;
            group.Note = dbGroup.Note;
            group.Sort = dbGroup.Sort;
            group.CreatedAt = dbGroup.CreatedAt;

            // update the sort for the exercise sets
            group.CompletedExerciseSets = group.CompletedExerciseSets
                .Select((set, index) =>
                {
                    set.Sort = index;
                    return set;
                });
        }

        return exerciseGroupsToSave;
    }

    private async Task<IEnumerable<CompletedExerciseGroup>> SaveCompletedExerciseGroupsSetsAsync(IEnumerable<CompletedExerciseGroup> exerciseGroups)
    {
        // Array for indexing due to async
        var exerciseGroupsWithSetsToSave = exerciseGroups.ToArray();

        for (var i = 0; i < exerciseGroupsWithSetsToSave.Length; i++)
        {
            var group = exerciseGroupsWithSetsToSave[i];
            var exerciseSets = group.CompletedExerciseSets.ToArray();

            for (var j = 0; j < exerciseSets.Length; j++)
            {
                var exerciseSet = exerciseSets[j];
                var dbSetToSave = new CompletedExerciseSetEntity(
                    exerciseSet.Id,
                    exerciseSet.Reps,
                    exerciseSet.Weight,
                    exerciseSet.MinReps,
                    exerciseSet.MaxReps,
                    exerciseSet.SetType,
                    exerciseSet.Sort,
                    group.Id);

                var savedDbSet = dbSetToSave.Id == 0
                    ? await _completedExerciseSetRepository.CreateCompletedExerciseSetEntityAsync(dbSetToSave)
                    : await _completedExerciseSetRepository.UpdateCompletedExerciseSetEntityAsync(dbSetToSave);

                exerciseSet.Id = savedDbSet.Id;
                exerciseSet.Reps = savedDbSet.Reps;
                exerciseSet.Weight = savedDbSet.Weight;
                exerciseSet.Sort = savedDbSet.Sort;
                exerciseSet.CreatedAt = savedDbSet.CreatedAt;
                exerciseSet.CompletedExerciseGroupId = savedDbSet.CompletedExerciseGroupId;
            }
        }

        return exerciseGroupsWithSetsToSave;
    }

    public async Task<IEnumerable<CompletedExerciseGroupHistory>> GetCompletedGroupHistoryByExerciseAsync(int exerciseId)
    {
        var dbGroupHistory = await _completedExerciseGroupRepository
            .GetCompletedGroupHistoryByExerciseIdAsync(exerciseId);

        var groupHistories = dbGroupHistory.Select(group =>
        {
            return new CompletedExerciseGroupHistory
            {
                CompletedExerciseGroupId = group.CompletedExerciseGroupId,
                Year = group.Year,
                Month = group.Month,
                Day = group.Day,
                ExerciseId = group.ExerciseId,
            };
        })
        .ToArray();

        for (var i = 0; i < groupHistories.Length; i++)
        {
            var group = groupHistories[i];
            var dbSets = await _completedExerciseSetRepository
                .GetAllCompletedExerciseSetEntitiesForCompletedGroupAsync(group.CompletedExerciseGroupId);

            group.CompletedExerciseSets = dbSets.Select(set =>
            {
                return new CompletedExerciseSet
                {
                    Id = set.Id,
                    Reps = set.Reps,
                    Weight = set.Weight,
                    Sort = set.Sort,
                    CreatedAt = set.CreatedAt,
                    CompletedExerciseGroupId = set.CompletedExerciseGroupId
                };
            });
        }

        return groupHistories;
    }
}