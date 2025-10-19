namespace WorkoutBackend.Api.Models;

public record CreateExerciseSet(int Reps, int Weight, int? ExerciseGroupId)
{ }

public record CreateExerciseGroup(string? Note, int ExerciseId, int? WorkoutId, IEnumerable<CreateExerciseSet> ExerciseSets)
{ }

public record CreateWorkout(string Name, int? ProgramId, IEnumerable<CreateExerciseGroup> ExerciseGroups)
{ }

public record UpdateExerciseSet(int Reps, int Weight, int? ExerciseGroupId)
{ }

public record UpdateExerciseGroup(string? Note, int ExerciseId, int? WorkoutId, IEnumerable<UpdateExerciseSet> ExerciseSets)
{ }

public record UpdateWorkout(int Id, string Name, int? ProgramId, IEnumerable<UpdateExerciseGroup> ExerciseGroups)
{ }
