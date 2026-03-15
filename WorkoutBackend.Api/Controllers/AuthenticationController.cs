using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutBackend.Api.Dtos;

namespace WorkoutBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserStore<IdentityUser> _userStore;
    private readonly IUserEmailStore<IdentityUser> _emailStore;

    public AuthenticationController(
        UserManager<IdentityUser> userManager,
        IUserStore<IdentityUser> userStore,
        SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _userStore = userStore;
        _emailStore = GetEmailStore();
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest registrationRequest)
    {
        var user = CreateUser();

        await _userStore.SetUserNameAsync(user, registrationRequest.Email, CancellationToken.None);
        await _emailStore.SetEmailAsync(user, registrationRequest.Email, CancellationToken.None);
        var result = await _userManager.CreateAsync(user, registrationRequest.Password);

        if (result.Succeeded)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok(new RegistrationResponse(true, [], userName));
        }

        var errorDescriptions = result.Errors.Select(err => err.Description);

        return BadRequest(new RegistrationResponse(false, errorDescriptions));
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<RegistrationResponse>> Login([FromBody] LoginRequest loginRequest)
    {
        var result = await _signInManager.PasswordSignInAsync(
            loginRequest.Email,
            loginRequest.Password,
            loginRequest.RememberMe,
            lockoutOnFailure: false);

        return result.Succeeded
            ? Ok(new RegistrationResponse(true, [], loginRequest.Email))
            : BadRequest(new RegistrationResponse(false, ["Unable to login. Check your email and password."]));
    }

    [HttpPost]
    [Route("logout")]
    public async Task<ActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return Ok();
    }

    [HttpGet]
    [Route("userInfo")]
    public async Task<ActionResult<UserInfoResponse>> GetUserInfo()
    {
        var user = HttpContext.User;

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return Ok(new UserInfoResponse(false));
        }

        var identity = await _userManager.GetUserAsync(HttpContext.User);

        return Ok(new UserInfoResponse(identity != null, identity?.Email));
    }

    private IdentityUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<IdentityUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        }
    }

    private IUserEmailStore<IdentityUser> GetEmailStore()
    {
        if (!_userManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<IdentityUser>)_userStore;
    }
}