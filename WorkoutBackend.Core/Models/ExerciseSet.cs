﻿namespace WorkoutBackend.Core.Models;

public class ExerciseSet
{
    public int Id { get; set; }
    public int? MinReps { get; set; }
    public int? MaxReps { get; set; }
    public double? Weight { get; set; }
    public int Sort { get; set; }
    public int ExerciseGroupId { get; set; }
}
