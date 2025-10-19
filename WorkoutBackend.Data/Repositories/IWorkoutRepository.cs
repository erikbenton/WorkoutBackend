using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories;

public interface IWorkoutRepository
{
    public Task<Workout> SaveWorkoutAsync(Workout workout);
    public Task<IEnumerable<WorkoutEntity>> GetAllWorkoutEntitiesAsync();
    public Task<WorkoutEntity> GetWorkoutEntityByIdAsync(int id);
    public Task<WorkoutEntity> CreateWorkoutEntityAsync(WorkoutEntity workout);
    public Task<WorkoutEntity> UpdateWorkoutEntityAsync(WorkoutEntity workout);
    public Task DeleteWorkoutEntityAsync(int id);
    public Task<Workout> GetWorkoutByIdAsync(int id);
}
