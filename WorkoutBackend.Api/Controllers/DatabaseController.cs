using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Data.Repositories.Database;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DatabaseController(IDatabaseRepository databaseRepository) : ControllerBase
{
    private readonly IDatabaseRepository _databaseRepository = databaseRepository;

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> CreateAllTablesAsync()
    {
        await _databaseRepository.CreateAllTablesAsync();

        return Ok("Created all tables");
    }

    [HttpPost]
    [Route("Drop")]
    public async Task<ActionResult> DropAllTablesAsync()
    {
        await _databaseRepository.DropAllTablesAsync();

        return Ok("Dropped all tables");
    }

    [HttpPost]
    [Route("Populate")]
    public async Task<ActionResult> PopulateDefaultsAsync()
    {
        await _databaseRepository.PopulateDefaultValues();

        return Ok("Populated defaults");
    }
}
