using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Repositories;
using WorkoutBackend.Data.Services;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutsController(
    IWorkoutRetriever workoutRetriever,
    IWorkoutSaver workoutSaver) : ControllerBase
{
    private readonly IWorkoutRetriever _workoutRetriever = workoutRetriever;
    private readonly IWorkoutSaver _workoutSaver = workoutSaver;

    [HttpGet]
    public async Task<ActionResult<Workout>> GetAllWorkoutsListAsync()
    {
        var shallowWorkouts = await _workoutRetriever.RetrieveAllWorkoutsList();

        return Ok(shallowWorkouts);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Workout>> GetPopulatedWorkoutById(int id)
    {
        var workout = await _workoutRetriever.RetrieveFullyPopulatedWorkoutAsync(id);

        return Ok(workout);
    }

    [HttpPost]
    public async Task<ActionResult<Workout>> CreateWorkoutAsync(Workout workout)
    {
        var savedWorkout = await _workoutSaver.SaveWorkoutAsync(workout);

        var populatedWorkout = await _workoutRetriever.RetrieveFullyPopulatedWorkoutAsync(savedWorkout.Id);

        return Ok(populatedWorkout);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Workout>> UpdateWorkoutAsync(Workout workout)
    {
        var savedWorkout = await _workoutSaver.SaveWorkoutAsync(workout);

        var populatedWorkout = await _workoutRetriever.RetrieveFullyPopulatedWorkoutAsync(savedWorkout.Id);

        return Ok(populatedWorkout);
    }
}
