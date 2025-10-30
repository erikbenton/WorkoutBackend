using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Workouts;

public interface IWorkoutRepository
{
    public Task<IEnumerable<WorkoutEntity>> GetAllWorkoutEntitiesAsync();
    public Task<IEnumerable<WorkoutSummaryEntry>> GetAllWorkoutSummariesEntriesAsync();
    public Task<WorkoutEntity> GetWorkoutEntityByIdAsync(int id);
    public Task<WorkoutEntity> CreateWorkoutEntityAsync(WorkoutEntity workout);
    public Task<WorkoutEntity> UpdateWorkoutEntityAsync(WorkoutEntity workout);
    public Task DeleteWorkoutEntityAsync(int id);
}
