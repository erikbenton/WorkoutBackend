using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Services;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompletedWorkoutsController(ICompletedWorkoutService completedWorkoutService) : ControllerBase
{
    private readonly ICompletedWorkoutService _completedWorkoutService = completedWorkoutService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompletedWorkoutSummary>>> GetCompletedWorkoutsSummariesAsync()
    {
        var summaries = await _completedWorkoutService.GetAllCompletedWorkoutSummariesAsync();

        return Ok(summaries);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompletedWorkout>> GetCompletedWorkoutByIdAsync(int id)
    {
        var completedWorkout = await _completedWorkoutService.GetCompletedWorkoutByIdAsync(id);

        return Ok(completedWorkout);
    }

    [HttpPost]
    public async Task<ActionResult<CompletedWorkout>> CreateCompletedWorkoutAsync([FromBody] CompletedWorkout completedWorkout)
    {
        var createdWorkout = await _completedWorkoutService.SaveCompletedWorkoutAsync(completedWorkout);

        return Ok(createdWorkout);
    }

    [HttpPut]
    public async Task<ActionResult<CompletedWorkout>> UpdateCompletedWorkoutByIdAsync([FromBody] CompletedWorkout completedWorkout)
    {
        var updatedWorkout = await _completedWorkoutService.SaveCompletedWorkoutAsync(completedWorkout);

        return Ok(updatedWorkout);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCompletedWorkoutByIdAsync(int id)
    {
        await _completedWorkoutService.DeleteCompletedWorkoutAsync(id);

        return NoContent();
    }
}
