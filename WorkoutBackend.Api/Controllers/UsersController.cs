using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Services;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserInfoService userInfoService, UserManager<IdentityUser> userManager) : ControllerBase
{
    private readonly IUserInfoService _userInfoService = userInfoService;
    private readonly UserManager<IdentityUser> _userManager = userManager;

    [HttpGet]
    public async Task<ActionResult<UserInfo>> GetUserInfo()
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var userInfo = await _userInfoService.GetUserInfo(identityUser.Id);

        return Ok(userInfo);
    }

    [HttpPut]
    public async Task<ActionResult<UserInfo>> UpdateUserInfo([FromBody]UserInfo userInfo)
    {
        var user = HttpContext.User;
        var identityUser = await _userManager.GetUserAsync(user);

        if (identityUser is null)
        {
            return Unauthorized("Not logged in.");
        }

        var updatedInfo = await _userInfoService.UpdateUserInfo(userInfo, identityUser.Id);

        return Ok(updatedInfo);
    }
}
