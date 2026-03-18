using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Services;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompletedExerciseGroupsController(
    ICompletedWorkoutService completedWorkoutService,
    UserManager<IdentityUser> userManager) : ControllerBase
{
    private readonly ICompletedWorkoutService _completedWorkoutService = completedWorkoutService;
    private readonly UserManager<IdentityUser> _userManager = userManager;

    [HttpGet("{exerciseId}")]
    public async Task<ActionResult<IEnumerable<CompletedExerciseGroupHistory>>>
        GetCompletedExerciseGroupsByExerciseAsync(int exerciseId)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var exerciseHistory = await _completedWorkoutService
            .GetCompletedGroupHistoryByExerciseAsync(exerciseId, identityUser.Id);

        return Ok(exerciseHistory);
    }
}
