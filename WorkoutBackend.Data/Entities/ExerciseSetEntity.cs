namespace WorkoutBackend.Data.Entities;

public record ExerciseSetEntity(int Id,
    int Reps,
    double Weight,
    int Sort,
    int ExerciseGroupId)
{ }
