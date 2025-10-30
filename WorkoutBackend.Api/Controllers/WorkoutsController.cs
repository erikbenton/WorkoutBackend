using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Services;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutsController(
    IWorkoutService workoutService) : ControllerBase
{
    private readonly IWorkoutService _workoutService = workoutService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkoutSummary>>> GetAllWorkoutsListAsync()
    {
        var workoutSummaries = await _workoutService.RetrieveAllWorkoutSummariesAsync();

        return Ok(workoutSummaries);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Workout>> GetPopulatedWorkoutById(int id)
    {
        var workout = await _workoutService.RetrieveFullyPopulatedWorkoutAsync(id);

        return Ok(workout);
    }

    [HttpPost]
    public async Task<ActionResult<Workout>> CreateWorkoutAsync([FromBody]Workout workout)
    {
        var savedWorkout = await _workoutService.SaveWorkoutAsync(workout);

        var populatedWorkout = await _workoutService.RetrieveFullyPopulatedWorkoutAsync(savedWorkout.Id);

        return Ok(populatedWorkout);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Workout>> UpdateWorkoutAsync([FromBody]Workout workout)
    {
        var savedWorkout = await _workoutService.SaveWorkoutAsync(workout);

        var populatedWorkout = await _workoutService.RetrieveFullyPopulatedWorkoutAsync(savedWorkout.Id);

        return Ok(populatedWorkout);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteWorkoutByIdAsync(int id)
    {
        await _workoutService.DeleteWorkoutByIdAsync(id);

        return NoContent();
    }
}
