namespace WorkoutBackend.Core.Models;

public class UserInfo
{
    public string? Username { get; set; }
    public double? BodyWeight { get; set; }
    public string WeightUnit { get; set; } = "lb";
    public string DistanceUnit { get; set; } = "mi";
}
