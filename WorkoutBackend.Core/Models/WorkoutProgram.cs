namespace WorkoutBackend.Core.Models;

public class WorkoutProgram
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string ColorRgb { get; set; } = string.Empty;

    public string Tag { get; set; } = string.Empty;

    public IEnumerable<int> WorkoutIds { get; set; } = [];
}
