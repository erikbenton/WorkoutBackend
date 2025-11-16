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
    [Route("PopulateSupport")]
    public async Task<ActionResult> PopulateSupportAsync()
    {
        await _databaseRepository.PopulateSupportValues();

        return Ok("Populated support tables");
    }

    [HttpPost]
    [Route("SeedData")]
    public async Task<ActionResult> SeedDataAsync()
    {
        await _databaseRepository.SeedData();

        return Ok("Seeded exercise and workouts data");
    }
}
