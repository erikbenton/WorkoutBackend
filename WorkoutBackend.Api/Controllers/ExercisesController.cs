using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Repositories;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExercisesController(IExerciseRepository exerciseRepository) : ControllerBase
{
    private readonly IExerciseRepository _exerciseRepository = exerciseRepository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetAllExercisesAsync()
    {
        var exercises = await _exerciseRepository.GetAllExercisesAsync();

        return Ok(exercises);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Exercise>> GetExerciseByIdAsync(int id)
    {
        var exercise = await _exerciseRepository.GetExerciseByIdAsync(id);

        return Ok(exercise);
    }

    [HttpGet("Name/{name}")]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExerciseByNameAsync(string name)
    {
        var exercise = await _exerciseRepository.GetExercisesByNameAsync(name);

        return Ok(exercise);
    }

    [HttpGet]
    [Route("BodyParts")]
    public async Task<ActionResult<IEnumerable<BodyPartOption>>> GetAllBodyPartOptionsAsync()
    {
        var bodyParts = await _exerciseRepository.GetAllBodyPartOptionsAsync();

        return Ok(bodyParts);
    }

    [HttpGet]
    [Route("Equipment")]
    public async Task<ActionResult<IEnumerable<BodyPartOption>>> GetAllEquipmentOptionsAsync()
    {
        var equipment = await _exerciseRepository.GetAllEquipmentOptionsAsync();

        return Ok(equipment);
    }

    [HttpPost]
    public async Task<ActionResult<Exercise>> CreateExerciseAsync(Exercise exercise)
    {
        var createdExercise = await _exerciseRepository.CreateExercise(exercise);

        return Ok(createdExercise);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Exercise>> UpdateExerciseAsync(Exercise exercise)
    {
        var updatedExercise = await _exerciseRepository.UpdateExerciseAsync(exercise);

        return Ok(updatedExercise);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteExerciseByIdAsync(int id)
    {
        await _exerciseRepository.DeleteExerciseByIdAsync(id);

        return NoContent();
    }
}
