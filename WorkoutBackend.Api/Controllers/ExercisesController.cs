using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Repositories.Exercises;
using WorkoutBackend.Data.Services;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExercisesController(IExerciseService exerciseService) : ControllerBase
{
    private readonly IExerciseService _exerciseService = exerciseService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetAllExercisesAsync()
    {
        var exercises = await _exerciseService.GetAllExercisesAsync();

        return Ok(exercises);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Exercise>> GetExerciseByIdAsync(int id)
    {
        var exercise = await _exerciseService.GetExerciseByIdAsync(id);

        return Ok(exercise);
    }

    [HttpGet("Name/{name}")]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExerciseByNameAsync(string name)
    {
        var exercise = await _exerciseService.GetExercisesByNameAsync(name);

        return Ok(exercise);
    }

    [HttpGet]
    [Route("BodyParts")]
    public async Task<ActionResult<IEnumerable<BodyPartOption>>> GetAllBodyPartOptionsAsync()
    {
        var bodyParts = await _exerciseService.GetExerciseBodyPartOptionsAsync();

        return Ok(bodyParts);
    }

    [HttpGet]
    [Route("Equipment")]
    public async Task<ActionResult<IEnumerable<BodyPartOption>>> GetAllEquipmentOptionsAsync()
    {
        var equipment = await _exerciseService.GetExerciseEquipmentOptionsAsync();

        return Ok(equipment);
    }

    [HttpPost]
    public async Task<ActionResult<Exercise>> CreateExerciseAsync(Exercise exercise)
    {
        var createdExercise = await _exerciseService.SaveExerciseAsync(exercise);

        return Ok(createdExercise);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Exercise>> UpdateExerciseAsync(Exercise exercise)
    {
        var updatedExercise = await _exerciseService.SaveExerciseAsync(exercise);

        return Ok(updatedExercise);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteExerciseByIdAsync(int id)
    {
        await _exerciseService.DeleteExerciseAsync(id);

        return NoContent();
    }
}
