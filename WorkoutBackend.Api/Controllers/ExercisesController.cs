using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Services;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExercisesController(IExerciseService exerciseService, UserManager<IdentityUser> userManager) : ControllerBase
{
    private readonly IExerciseService _exerciseService = exerciseService;
    private readonly UserManager<IdentityUser> _userManager = userManager;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetAllExercisesAsync()
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        string? userId = identityUser is null ? null : identityUser.Id;

        var exercises = await _exerciseService.GetAllExercisesAsync(userId);

        return Ok(exercises);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Exercise>> GetExerciseByIdAsync(int id)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        string? userId = identityUser is null ? null : identityUser.Id;

        var exercise = await _exerciseService.GetExerciseByIdAsync(id, userId);

        return Ok(exercise);
    }

    [HttpGet("Name/{name}")]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExerciseByNameAsync(string name)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        string? userId = identityUser is null ? null : identityUser.Id;

        var exercise = await _exerciseService.GetExercisesByNameAsync(name, userId);

        return Ok(exercise);
    }

    [HttpGet]
    [Route("Muscles")]
    public async Task<ActionResult<IEnumerable<MuscleOption>>> GetAllBodyPartOptionsAsync()
    {
        var bodyParts = await _exerciseService.GetExerciseMuscleOptionsAsync();

        return Ok(bodyParts);
    }

    [HttpGet]
    [Route("Equipment")]
    public async Task<ActionResult<IEnumerable<EquipmentOption>>> GetAllEquipmentOptionsAsync()
    {
        var equipment = await _exerciseService.GetExerciseEquipmentOptionsAsync();

        return Ok(equipment);
    }

    [HttpPost]
    public async Task<ActionResult<Exercise>> CreateExerciseAsync(Exercise exercise)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var createdExercise = await _exerciseService.SaveExerciseAsync(exercise, identityUser.Id);

        return Ok(createdExercise);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Exercise>> UpdateExerciseAsync(Exercise exercise)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var updatedExercise = await _exerciseService.SaveExerciseAsync(exercise, identityUser.Id);

        return Ok(updatedExercise);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteExerciseByIdAsync(int id)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        await _exerciseService.DeleteExerciseAsync(id, identityUser.Id);

        return NoContent();
    }
}
