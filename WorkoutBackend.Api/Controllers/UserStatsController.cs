using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Services;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserStatsController(IUserStatsService userStatsService, UserManager<IdentityUser> userManager) : ControllerBase
{
    private readonly IUserStatsService _userStatsService = userStatsService;
    private readonly UserManager<IdentityUser> _userManager = userManager;

    [HttpGet("{numberOfDays}")]
    public async Task<ActionResult<UserStats>> GetAllExercisesAsync(int numberOfDays)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var userStats = await _userStatsService.GetUserStatsAsync(numberOfDays, identityUser.Id);

        return Ok(userStats);
    }
}
