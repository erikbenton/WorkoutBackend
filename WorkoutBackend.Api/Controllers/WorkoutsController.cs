using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Services;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutsController(
    IWorkoutService workoutService,
    UserManager<IdentityUser> userManager) : ControllerBase
{
    private readonly IWorkoutService _workoutService = workoutService;
    private readonly UserManager<IdentityUser> _userManager = userManager;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Workout>>> GetAllWorkoutsListAsync()
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var workoutSummaries = await _workoutService.RetrieveAllWorkoutsAsync(identityUser.Id);

        return Ok(workoutSummaries);
    }

    [HttpGet]
    [Route("SetTagOptions")]
    public async Task<ActionResult<IEnumerable<SetTagOption>>> GetSetTagOptions()
    {
        var setTagOptions = await _workoutService.GetSetTagOptionsAsync();

        return Ok(setTagOptions);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Workout>> GetPopulatedWorkoutById(int id)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var workout = await _workoutService.RetrieveFullyPopulatedWorkoutAsync(id, identityUser.Id);

        return Ok(workout);
    }

    [HttpPost]
    public async Task<ActionResult<Workout>> CreateWorkoutAsync([FromBody]Workout workout)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var savedWorkout = await _workoutService.SaveWorkoutAsync(workout, identityUser.Id);

        var populatedWorkout = await _workoutService.RetrieveFullyPopulatedWorkoutAsync(savedWorkout.Id, identityUser.Id);

        return Ok(populatedWorkout);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Workout>> UpdateWorkoutAsync([FromBody]Workout workout)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var savedWorkout = await _workoutService.SaveWorkoutAsync(workout, identityUser.Id);

        var populatedWorkout = await _workoutService.RetrieveFullyPopulatedWorkoutAsync(savedWorkout.Id, identityUser.Id);

        return Ok(populatedWorkout);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteWorkoutByIdAsync(int id)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        await _workoutService.DeleteWorkoutByIdAsync(id, identityUser.Id);

        return NoContent();
    }
}
