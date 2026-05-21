using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Services;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgramsController(
    IWorkoutProgramService workoutProgramService,
    UserManager<IdentityUser> userManager) : ControllerBase
{
    private readonly IWorkoutProgramService _workoutProgramService = workoutProgramService;
    private readonly UserManager<IdentityUser> _userManager = userManager;

    [HttpGet]
    public async Task<ActionResult> GetProgramsAllAsync()
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var programs = await _workoutProgramService.GetAllProgramsAsync(identityUser.Id);

        return Ok(programs);
    }

    [HttpPost]
    public async Task<ActionResult<WorkoutProgram>> CreateProgram([FromBody]WorkoutProgram program)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var createdprogram = await _workoutProgramService.SaveProgramAsync(program, identityUser.Id);

        return Ok(createdprogram);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<WorkoutProgram>> UpdateProgram([FromBody] WorkoutProgram program)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var createdprogram = await _workoutProgramService.SaveProgramAsync(program, identityUser.Id);

        return Ok(createdprogram);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteProgram(int id)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        await _workoutProgramService.DeleteProgramAsync(id, identityUser.Id);

        return NoContent();
    }
}
