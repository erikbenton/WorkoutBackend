using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Entities;
using WorkoutBackend.Data.Repositories;
using WorkoutBackend.Data.Repositories.Exercises;
using WorkoutBackend.Data.Repositories.Workouts;
using WorkoutBackend.Data.Services;
using WorkoutBackend.IntegrationTests.Helpers;

namespace WorkoutBackend.IntegrationTests;

public class WorkoutRepositoryTests
{
    IWorkoutRepository workoutRepository;
    IExerciseGroupRepository exerciseGroupRepository;
    IExerciseSetRepository exerciseSetRepository;
    IExerciseRepository exerciseRepository;
    IWorkoutService workoutService;

    [OneTimeSetUp]
    public async Task WorkoutOneTimeSetup()
    {
        await DatabaseHelper.RefreshDatabase();
        await ExerciseHelper.InitializeExercises();
        await WorkoutHelper.InitializeWorkouts();
    }

    [SetUp]
    public void WorkoutSetUp()
    {
        workoutRepository = new SqlWorkoutRepository(DatabaseHelper.TestConnectionString);
        exerciseGroupRepository = new SqlExerciseGroupRepository(DatabaseHelper.TestConnectionString);
        exerciseSetRepository = new SqlExerciseSetRepository(DatabaseHelper.TestConnectionString);
        exerciseRepository = new SqlExerciseRepository(DatabaseHelper.TestConnectionString);
        workoutService = new WorkoutService(workoutRepository, exerciseGroupRepository, exerciseSetRepository, exerciseRepository);
    }

    [Test]
    public async Task CanCreateNewDbWorkout()
    {
        var workout = new WorkoutEntity(0, "Test Workout", "Test Description", null);

        var savedWorkout = await workoutRepository.CreateWorkoutEntityAsync(workout);

        Assert.That(savedWorkout.Id, Is.Not.EqualTo(0));
        Assert.That(savedWorkout.Name, Is.EqualTo(workout.Name));
        Assert.That(savedWorkout.Description, Is.EqualTo(workout.Description));
        Assert.That(savedWorkout.ProgramId, Is.Null);
    }

    [Test]
    public async Task CanGetAllDbWorkouts()
    {
        var workouts = await workoutRepository.GetAllWorkoutEntitiesAsync();

        Assert.That(workouts, Is.Not.Empty);
    }

    [Test]
    public async Task CanUpdateExistingWorkout()
    {
        var workouts = await workoutRepository.GetAllWorkoutEntitiesAsync();

        var workoutToUpdate = workouts.First();

        var beforeUpdate = new WorkoutEntity(
            workoutToUpdate.Id,
            "Updated Name",
            "Updated Description",
            workoutToUpdate.ProgramId);

        var afterUpdate = await workoutRepository.UpdateWorkoutEntityAsync(beforeUpdate);

        Assert.That(afterUpdate.Id, Is.EqualTo(beforeUpdate.Id));
        Assert.That(afterUpdate.Name, Is.EqualTo(beforeUpdate.Name));
        Assert.That(afterUpdate.Description, Is.EqualTo(beforeUpdate.Description));
        Assert.That(afterUpdate.ProgramId, Is.EqualTo(beforeUpdate.ProgramId));
    }

    [Test]
    public async Task CanGetDbWorkoutById()
    {
        var workouts = await workoutRepository.GetAllWorkoutEntitiesAsync();

        var workout = workouts.First();

        var retrievedWorkout = await workoutRepository.GetWorkoutEntityByIdAsync(workout.Id);

        Assert.That(retrievedWorkout.Id, Is.EqualTo(workout.Id));
        Assert.That(retrievedWorkout.Name, Is.EqualTo(workout.Name));
        Assert.That(retrievedWorkout.ProgramId, Is.EqualTo(workout.ProgramId));
    }

    [Test]
    public async Task CanDeleteDbWorkoutById()
    {
        var workoutsBeforeDeletion = await workoutRepository.GetAllWorkoutEntitiesAsync();

        var workoutToDelete = workoutsBeforeDeletion.First();

        await workoutRepository.DeleteWorkoutEntityAsync(workoutToDelete.Id);

        var workoutsAfterDeletion = await workoutRepository.GetAllWorkoutEntitiesAsync();

        var workoutIdsAfterDeletion = workoutsAfterDeletion.Select(w => w.Id);

        Assert.That(workoutIdsAfterDeletion, Does.Not.Contain(workoutToDelete.Id));
    }

    [Test]
    public async Task CanSaveANewWorkout()
    {
        var workout = new Workout()
        {
            Name = "Legs",
            ExerciseGroups = new[]
            {
                new ExerciseGroup()
                {
                    Exercise = new Exercise()
                    {
                        Id = 1,
                        Name = "Exercise 1"
                    },
                    ExerciseSets = []
                },
                new ExerciseGroup()
                {
                    Exercise = new Exercise()
                    {
                        Id = 2,
                        Name = "Exercise 2"
                    },
                    ExerciseSets = []
                },

            }
        };

        var savedWorkout = await workoutService.SaveWorkoutAsync(workout);

        Assert.That(savedWorkout.Id, Is.Not.EqualTo(0));
        Assert.That(savedWorkout.Name, Is.EqualTo(workout.Name));

        Assert.Multiple(() =>
        {
            foreach (var group in savedWorkout.ExerciseGroups)
            {
                Assert.That(group.WorkoutId, Is.EqualTo(savedWorkout.Id));
            }
        });

        var exerciseGroupSorts = savedWorkout.ExerciseGroups.Select(group => group.Sort);

        Assert.That(exerciseGroupSorts, Is.EquivalentTo(new List<int>() { 0, 1 }));
    }

    [Test]
    public async Task CanUpdateAnExistingWorkout()
    {
        var workouts = await workoutRepository.GetAllWorkoutEntitiesAsync();
        var workout = await workoutService.RetrieveFullyPopulatedWorkoutAsync(workouts.First().Id);

        workout.Name = "Updated workout name";

        var updatedWorkout = await workoutService.SaveWorkoutAsync(workout);

        Assert.That(updatedWorkout.Id, Is.EqualTo(workout.Id));
        Assert.That(updatedWorkout.Name, Is.EqualTo(workout.Name));
    }

    [Test]
    public async Task CanSaveAFullWorkout()
    {
        var exercises = await exerciseRepository.GetAllExercisesAsync();
        var benchPress = exercises.First(ex => ex.Name.Contains("Bench Press"));
        var pullUp = exercises.First(ex => ex.Name.Contains("Pull-Up"));
        var shoulderPress = exercises.First(ex => ex.Name.Contains("Shoulder Press"));

        var workout = new Workout()
        {
            Name = "Day A",
            ExerciseGroups = new[]
            {
                new ExerciseGroup()
                {
                    Exercise = benchPress,
                    Note = "Try to go heavy. If you can do more than 5 reps on a work set, increase the total weight by 5lbs.",
                    ExerciseSets = new []
                    {
                        new ExerciseSet()
                        {
                            MinReps = 10,
                            SetType = "warm up"
                        },
                        new ExerciseSet()
                        {
                            MinReps = 8,
                            SetType = "warm up"
                        },
                        new ExerciseSet()
                        {
                            MinReps = 4,
                            MaxReps = 6,
                            SetType = "work"
                        },
                        new ExerciseSet()
                        {
                            MinReps = 4,
                            MaxReps = 6,
                            SetType = "work"
                        },
                        new ExerciseSet()
                        {
                            MinReps = 4,
                            MaxReps = 6,
                            SetType = "work"
                        }
                    }
                },
                new ExerciseGroup()
                {
                    Exercise = pullUp,
                    Note = "Try to increase the reps you can do, but if you can do more than 10 in a set, do another set instead of going past 10 reps.",
                    ExerciseSets = new []
                    {
                        new ExerciseSet()
                        {
                            MinReps = 6,
                            MaxReps = 10
                        },
                        new ExerciseSet()
                        {
                            MinReps = 6,
                            MaxReps = 10
                        },
                        new ExerciseSet()
                        {
                            MinReps = 6,
                            MaxReps = 10
                        }
                    }
                },
                new ExerciseGroup()
                {
                    Exercise = shoulderPress,
                    Note = "Go slow and try not pinch/stress out your neck.",
                    ExerciseSets = new []
                    {
                        new ExerciseSet()
                        {
                            MinReps = 6,
                            MaxReps = 8,
                            SetType = "work"
                        },
                        new ExerciseSet()
                        {
                            MinReps = 6,
                            MaxReps = 8,
                            SetType = "work"
                        },
                        new ExerciseSet()
                        {
                            MinReps = 6,
                            MaxReps = 8,
                            SetType = "work"
                        }
                    }
                }
            }
        };

        var savedWorkout = await workoutService.SaveWorkoutAsync(workout);

        Assert.That(savedWorkout.Id, Is.Not.EqualTo(0));
        Assert.That(savedWorkout.Name, Is.EqualTo(workout.Name));

        Assert.That(savedWorkout.ExerciseGroups.Count(), Is.EqualTo(workout.ExerciseGroups.Count()));
    }

}
