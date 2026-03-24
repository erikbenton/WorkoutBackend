namespace WorkoutBackend.Data.DataAccess;

public static class UserStatsDataAccess
{
    private static readonly string sqlFolder = "Sql/UserStats";

    public static string GeneralStatsBeforeEqualEndDate => DataAccessHelper.GetSqlString(sqlFolder, "GeneralStatsBeforeEqualEndDate.sql");
}
