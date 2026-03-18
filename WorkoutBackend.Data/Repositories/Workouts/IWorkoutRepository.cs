using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Workouts;

public interface IWorkoutRepository
{
    public Task<IEnumerable<WorkoutEntity>> GetAllWorkoutEntitiesAsync(string userId);
    public Task<IEnumerable<SetTagOption>> GetAllSetTagOptionsAsync();
    public Task<IEnumerable<WorkoutSummaryEntry>> GetAllWorkoutSummariesEntriesAsync(string userId);
    public Task<WorkoutEntity> GetWorkoutEntityByIdAsync(int id, string userId);
    public Task<WorkoutEntity> CreateWorkoutEntityAsync(WorkoutEntity workout);
    public Task<WorkoutEntity> UpdateWorkoutEntityAsync(WorkoutEntity workout);
    public Task DeleteWorkoutEntityAsync(int id, string userId);
}
