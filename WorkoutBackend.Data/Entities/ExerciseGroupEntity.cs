﻿namespace WorkoutBackend.Data.Entities;

public record ExerciseGroupEntity(int Id,
    string? Note,
    int Sort,
    int ExerciseId,
    int WorkoutId)
{ }
