using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Services;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompletedWorkoutsController(
    ICompletedWorkoutService completedWorkoutService,
    UserManager<IdentityUser> userManager) : ControllerBase
{
    private readonly ICompletedWorkoutService _completedWorkoutService = completedWorkoutService;
    private readonly UserManager<IdentityUser> _userManager = userManager;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompletedWorkout>>> GetAllCompletedWorkoutsAsync()
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var summaries = await _completedWorkoutService.GetAllCompletedWorkoutsPopulatedAsync(identityUser.Id);

        return Ok(summaries);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompletedWorkout>> GetCompletedWorkoutByIdAsync(int id)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var completedWorkout = await _completedWorkoutService.GetCompletedWorkoutByIdAsync(id, identityUser.Id);

        return Ok(completedWorkout);
    }

    [HttpPost]
    public async Task<ActionResult<CompletedWorkout>> CreateCompletedWorkoutAsync([FromBody] CompletedWorkout completedWorkout)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var createdWorkout = await _completedWorkoutService.SaveCompletedWorkoutAsync(completedWorkout, identityUser.Id);

        return Ok(createdWorkout);
    }

    [HttpPut]
    public async Task<ActionResult<CompletedWorkout>> UpdateCompletedWorkoutByIdAsync([FromBody] CompletedWorkout completedWorkout)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var updatedWorkout = await _completedWorkoutService.SaveCompletedWorkoutAsync(completedWorkout, identityUser.Id);

        return Ok(updatedWorkout);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCompletedWorkoutByIdAsync(int id)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        await _completedWorkoutService.DeleteCompletedWorkoutAsync(id, identityUser.Id);

        return NoContent();
    }
}
