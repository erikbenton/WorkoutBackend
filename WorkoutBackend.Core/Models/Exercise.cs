namespace WorkoutBackend.Core.Models;

public class Exercise
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Instructions { get; set; }
    public string? Category { get; set; }
    public IEnumerable<MuscleData>? Muscles { get; set; }
    public string? Equipment { get; set; }
}
