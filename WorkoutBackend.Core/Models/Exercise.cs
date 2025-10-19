namespace WorkoutBackend.Core.Models;

public class Exercise
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Instructions { get; set; }
    public string? BodyPart { get; set; }
    public string? Equipment { get; set; }
}
