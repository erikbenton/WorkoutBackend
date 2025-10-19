namespace WorkoutBackend.Data.DataAccess;

public static class DataAccessHelper
{
    public static string GetSqlString(string fileLocation, string fileName)
    {
        // Ensure that the location is relative between projects
        var baseLocation = AppDomain.CurrentDomain.BaseDirectory + fileLocation;
        return File.ReadAllText($"{baseLocation}/{fileName}");
    }
}
