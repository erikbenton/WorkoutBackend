using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Services;

public interface IWorkoutProgramService
{
    public Task<IEnumerable<WorkoutProgram>> GetAllProgramsAsync(string userId);
    public Task<WorkoutProgram> SaveProgramAsync(WorkoutProgram program, string userId);
    public Task DeleteProgramAsync(int id, string userId);
}
