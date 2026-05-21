using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Repositories.Programs;
using WorkoutBackend.Data.Services;
using WorkoutBackend.IntegrationTests.Helpers;

namespace WorkoutBackend.IntegrationTests;

public class WorkoutProgramRepositoryTests
{
    IProgramRepository programRepository;
    IWorkoutProgramService programService;
    private string testId;

    [OneTimeSetUp]
    public async Task WorkoutOneTimeSetup()
    {
        await DatabaseHelper.RefreshDatabase();
        await ExerciseHelper.InitializeExercises();
        await WorkoutHelper.InitializeWorkouts();
        testId = await DatabaseHelper.GetTestUserId();
    }

    [SetUp]
    public void WorkoutSetUp()
    {
        programRepository = new SqlProgramRepository(DatabaseHelper.TestConnectionString);
        programService = new WorkoutProgramService(programRepository);
    }

    [Test]
    public async Task CanCreateNewProgram()
    {
        var program = new WorkoutProgram()
        {
            Id = 0,
            Name = "Test Program",
            Description = "This is a program made during testing",
            WorkoutIds = [1, 2]
        };

        var savedProgram = await programService.SaveProgramAsync(program, testId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(savedProgram.Id, Is.Not.Zero);
            Assert.That(savedProgram.Name, Is.EqualTo(program.Name));
            Assert.That(savedProgram.Description, Is.EqualTo(program.Description));
            Assert.That(savedProgram.WorkoutIds, Is.EquivalentTo([1, 2]));
        }
    }
}
