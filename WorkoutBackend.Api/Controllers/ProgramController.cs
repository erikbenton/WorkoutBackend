using Microsoft.AspNetCore.Mvc;

namespace WorkoutBackend.Api.Controllers
{
    public class ProgramController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetProgramsAsync()
        {
            return Ok();
        }
    }
}
