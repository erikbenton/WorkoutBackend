using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Repositories.Programs;

namespace WorkoutBackend.Data.Services;

public class WorkoutProgramService(IProgramRepository programRepository) : IWorkoutProgramService
{
    private readonly IProgramRepository _programRepository = programRepository;

    public async Task DeleteProgramAsync(int id, string userId)
    {
        await _programRepository.DeleteProgramAsync(id, userId);
    }

    public async Task<IEnumerable<WorkoutProgram>> GetAllProgramsAsync(string userId)
    {
        return await _programRepository.GetAllProgramsPopulatedAsync(userId);
    }

    public async Task<WorkoutProgram> SaveProgramAsync(WorkoutProgram program, string userId)
    {
        return program.Id == 0
            ? await _programRepository.CreateProgramAsync(program, userId)
            : await _programRepository.UpdateProgramAsync(program, userId);
    }
}
