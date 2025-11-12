using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Services;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompletedExerciseGroupsController(ICompletedWorkoutService completedWorkoutService) : ControllerBase
{
    private readonly ICompletedWorkoutService _completedWorkoutService = completedWorkoutService;

    [HttpGet("{exerciseId}")]
    public async Task<ActionResult<IEnumerable<CompletedExerciseGroupHistory>>>
        GetCompletedExerciseGroupsByExerciseAsync(int exerciseId)
    {
        var exerciseHistory = await _completedWorkoutService
            .GetCompletedGroupHistoryByExerciseAsync(exerciseId);

        return Ok(exerciseHistory);
    }
}
