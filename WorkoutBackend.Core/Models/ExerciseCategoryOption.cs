namespace WorkoutBackend.Core.Models;

public record ExerciseCategoryOption(
    int Id,
    string Name,
    string ColorRgb,
    string FirstTargetInput,
    string SecondTargetInput,
    string FirstInput,
    string SecondInput);