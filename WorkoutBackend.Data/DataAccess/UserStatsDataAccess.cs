namespace WorkoutBackend.Data.DataAccess;

public static class UserStatsDataAccess
{
    private static readonly string sqlFolder = "Sql/UserStats";

    public static string WorkoutStatsBeforeEqualsEndDate => DataAccessHelper.GetSqlString(sqlFolder, "WorkoutStatsBeforeEqualsEndDate.sql");
    public static string SetStatsBeforeEqualsEndDate => DataAccessHelper.GetSqlString(sqlFolder, "SetStatsBeforeEqualsEndDate.sql");
}
