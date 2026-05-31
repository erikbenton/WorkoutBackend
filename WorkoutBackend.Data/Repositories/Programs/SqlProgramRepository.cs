using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Programs;

public class SqlProgramRepository(string connectionString) : IProgramRepository
{
    private readonly string _connectionString = connectionString;

    public async Task<WorkoutProgram> CreateProgramAsync(WorkoutProgram program, string userId)
    {
        using var connection = new SqlConnection(_connectionString);

        var programToInsert = new ProgramEntity(0, program.Name, program.ColorRgb, program.Description, userId);
        var insertedProgram = await connection.QueryFirstAsync<ProgramEntity>(ProgramDataAccess.InsertProgram, programToInsert);
        var programWorkouts = program.WorkoutIds.Select((id, i) => new ProgramWorkoutEntity(null, insertedProgram.Id, id, i, userId));

        await connection.ExecuteAsync(ProgramDataAccess.InsertProgramWorkout, programWorkouts);
        var insertedProgramWorkouts = await connection
            .QueryAsync<ProgramWorkoutEntity>(ProgramDataAccess.GetAllProgramWorkoutsByProgramId, new { programId = insertedProgram.Id, userId });
        
        var workoutIds = insertedProgramWorkouts.Select(wp => wp.WorkoutId);
        WorkoutProgram savedProgram = new()
        {
            Id = insertedProgram.Id,
            Name = insertedProgram.Name,
            ColorRgb = insertedProgram.ColorRgb,
            Description = insertedProgram.Description,
            WorkoutIds = workoutIds
        };

        return savedProgram;
    }

    public async Task DeleteProgramAsync(int id, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(ProgramDataAccess.DeleteProgramWorkoutsByProgramId, new { ProgramId = id, userId });
        await connection.ExecuteAsync(ProgramDataAccess.DeleteProgram, new { id, userId });
    }

    public async Task<IEnumerable<WorkoutProgram>> GetAllProgramsPopulatedAsync(string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        List<WorkoutProgram> programsWithWorkoutIds = [];
        var results = await connection.QueryMultipleAsync(ProgramDataAccess.GetAllProgramsWithWorkoutIds, new { userId });

        var programs = results.Read<ProgramEntity>();
        var workouts = results.Read<ProgramWorkoutEntity>();

        foreach (var program in programs)
        {
            var workoutIds = workouts
                .Where(w => w.ProgramId == program.Id)
                .OrderBy(w => w.Sort)
                .Select(w => w.WorkoutId);

            WorkoutProgram programWithWorkoutIds = new()
            {
                Id = program.Id,
                Name = program.Name,
                ColorRgb = program.ColorRgb,
                Description = program.Description,
                WorkoutIds = workoutIds
            };
            programsWithWorkoutIds.Add(programWithWorkoutIds);
        }

        return programsWithWorkoutIds;
    }

    public async Task<WorkoutProgram> UpdateProgramAsync(WorkoutProgram program, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var programToUpdate = new ProgramEntity(program.Id, program.Name, program.ColorRgb, program.Description, userId);
        var updatedProgramEntity = await connection.QueryFirstAsync<ProgramEntity>(ProgramDataAccess.UpdateProgram, programToUpdate);

        // delete all of the old ProgramWorkouts
        await connection.ExecuteAsync(ProgramDataAccess.DeleteProgramWorkoutsByProgramId, new { ProgramId = updatedProgramEntity.Id, userId });

        // insert all of the workoutIds as "new" ProgramWorkout relationships
        var programWorkoutEntitiesToSave = program.WorkoutIds
            .Select((id, i) => new ProgramWorkoutEntity(null, updatedProgramEntity.Id, id, i, userId));

        await connection.ExecuteAsync(ProgramDataAccess.InsertProgramWorkout, programWorkoutEntitiesToSave);

        var insertedWorkoutPrograms = await connection
            .QueryAsync<ProgramWorkoutEntity>(ProgramDataAccess.GetAllProgramWorkoutsByProgramId, new { programId = updatedProgramEntity.Id, userId });

        var workoutIds = insertedWorkoutPrograms.OrderBy(wp => wp.Sort).Select(wp => wp.WorkoutId);
        WorkoutProgram updatedProgram = new()
        {
            Id = updatedProgramEntity.Id,
            Name = updatedProgramEntity.Name,
            ColorRgb = updatedProgramEntity.ColorRgb,
            Description = updatedProgramEntity.Description,
            WorkoutIds = insertedWorkoutPrograms.OrderBy(wp => wp.Sort).Select(wp => wp.WorkoutId)
        };

        return updatedProgram;
    }
}
