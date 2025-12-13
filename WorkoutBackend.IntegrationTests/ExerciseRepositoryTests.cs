using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Repositories;
using WorkoutBackend.Data.Repositories.Exercises;
using WorkoutBackend.IntegrationTests.Helpers;

namespace WorkoutBackend.IntegrationTests;

public class ExerciseRepositoryTests
{
    IExerciseRepository _exerciseRepository;

    [OneTimeSetUp]
    public async Task ExercisesOneTimeSetup()
    {
        await DatabaseHelper.RefreshDatabase();
        await ExerciseHelper.InitializeExercises();
    }

    [SetUp]
    public void Setup()
    {
        _exerciseRepository = new SqlExerciseRepository(DatabaseHelper.TestConnectionString);   
    }

    [Test]
    public async Task CanGetAllExercisesAsync()
    {
        var exercises = await _exerciseRepository.GetAllExercisesAsync();

        Assert.That(exercises, Is.Not.Null);
    }

    [Test]
    public async Task CanGetExerciseByIdAsync()
    {
        var exercises = await _exerciseRepository.GetAllExercisesAsync();
        var exerciseToRetrieve = exercises.First();
        var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseToRetrieve.Id);

        Assert.That(exercise, Is.Not.Null);
        Assert.That(exercise.Id, Is.EqualTo(exerciseToRetrieve.Id));
    }

    [Test]
    public async Task CanInsertNewExerciseAsync()
    {
        var exercise = new Exercise()
        {
            Id = 0,
            Name = "Deadlift",
            Instructions = "Do a deadlift.",
            BodyPart = "upper legs",
            Equipment = "barbell"
        };

        var savedExercise = await _exerciseRepository.CreateExerciseAsync(exercise);

        Assert.Multiple(() =>
        {
            Assert.That(savedExercise.Id, Is.Not.EqualTo(0));
            Assert.That(savedExercise.Name, Is.EqualTo(exercise.Name));
            Assert.That(savedExercise.Instructions, Is.EqualTo(exercise.Instructions));
            Assert.That(savedExercise.BodyPart, Is.EqualTo(exercise.BodyPart));
            Assert.That(savedExercise.Equipment, Is.EqualTo(exercise.Equipment));
        });
    }

    [Test]
    public async Task CanUpdateAnExistingExercise()
    {
        var exercises = await _exerciseRepository.GetAllExercisesAsync();
        var exerciseToUpdate = exercises.First();

        exerciseToUpdate.Name = "Updated name";
        exerciseToUpdate.Instructions = "These are new instructions";
        exerciseToUpdate.BodyPart = exerciseToUpdate.BodyPart == "back" ? "biceps" : "back";
        exerciseToUpdate.Equipment = exerciseToUpdate.Equipment == "barbell" ? "machine" : "barbell";

        var updatedExercise = await _exerciseRepository.UpdateExerciseAsync(exerciseToUpdate);

        Assert.That(updatedExercise.Id, Is.EqualTo(exerciseToUpdate.Id));
        Assert.That(updatedExercise.Name, Is.EqualTo(exerciseToUpdate.Name));
        Assert.That(updatedExercise.Instructions, Is.EqualTo(exerciseToUpdate.Instructions));
        Assert.That(updatedExercise.BodyPart, Is.EqualTo(exerciseToUpdate.BodyPart));
        Assert.That(updatedExercise.Equipment, Is.EqualTo(exerciseToUpdate.Equipment));
    }

    [Test]
    [TestCase("Bench")]
    [TestCase("Pull-Up")]
    public async Task CanGetExerciseByNameAsync(string name)
    {
        var exercises = await _exerciseRepository.GetExercisesByNameAsync(name);

        Assert.That(exercises, Is.Not.Empty);

        var exerciseNames = exercises.Select(x => x.Name);

        Assert.Multiple(() =>
        {
            foreach (var exerciseName in exerciseNames)
            {
                Assert.That(exerciseName.Contains(name), Is.True);
            }
        });
    }

    [Test]
    public async Task CanDeleteExerciseById()
    {
        var exercises = await _exerciseRepository.GetAllExercisesAsync();
        var exerciseToDelete = exercises.First();

        await _exerciseRepository.DeleteExerciseByIdAsync(exerciseToDelete.Id);

        var exercisesAfterDelete = await _exerciseRepository.GetAllExercisesAsync();

        var exerciseIds = exercisesAfterDelete.Select(x => x.Id);

        Assert.That(exerciseIds, Does.Not.Contain(exerciseToDelete.Id));
    }

    [Test]
    public async Task CanGetAllBodyPartOptions()
    {
        var bodyPartOptions = await _exerciseRepository.GetAllBodyPartOptionsAsync();

        Assert.That(bodyPartOptions, Is.Not.Empty);
        Assert.That(bodyPartOptions.ToList(), Has.Count.GreaterThan(5));
    }

    [Test]
    public async Task CanGetAllEquipmentOptions()
    {
        var equipmentOptions = await _exerciseRepository.GetAllEquipmentOptionsAsync();

        Assert.That(equipmentOptions, Is.Not.Empty);
        Assert.That(equipmentOptions.ToList(), Has.Count.GreaterThan(5));
    }
}
