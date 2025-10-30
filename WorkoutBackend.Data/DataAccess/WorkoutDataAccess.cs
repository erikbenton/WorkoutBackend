namespace WorkoutBackend.Data.DataAccess;

public static class WorkoutDataAccess
{
    private static readonly string sqlFolder = "Sql/Workouts";

    public static string GetWorkoutById => DataAccessHelper.GetSqlString(sqlFolder, "GetWorkoutById.sql");
    public static string GetAllWorkouts => DataAccessHelper.GetSqlString(sqlFolder, "GetAllWorkouts.sql");
    public static string GetAllWorkoutSummaryEntries => DataAccessHelper.GetSqlString(sqlFolder, "GetAllWorkoutSummaryEntries.sql");
    public static string InsertWorkoutNoProgramId => DataAccessHelper.GetSqlString(sqlFolder, "InsertWorkoutNoProgramId.sql");
    public static string InsertWorkoutWithProgramId => DataAccessHelper.GetSqlString(sqlFolder, "InsertWorkoutWithProgramId.sql");
    public static string InsertWorkoutWithProgramName => DataAccessHelper.GetSqlString(sqlFolder, "InsertWorkoutWithProgramName.sql");
    public static string DeleteWorkoutById => DataAccessHelper.GetSqlString(sqlFolder, "DeleteWorkoutById.sql");
    public static string UpdateWorkoutById => DataAccessHelper.GetSqlString(sqlFolder, "UpdateWorkoutById.sql");
}
