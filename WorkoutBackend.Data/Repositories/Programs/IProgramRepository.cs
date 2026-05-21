using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Repositories.Programs;

public interface IProgramRepository
{
    public Task<IEnumerable<WorkoutProgram>> GetAllProgramsPopulatedAsync(string userId);
    public Task<WorkoutProgram> UpdateProgramAsync(WorkoutProgram program, string userId);
    public Task<WorkoutProgram> CreateProgramAsync(WorkoutProgram program, string userId);
    public Task DeleteProgramAsync(int id, string userId);
}
