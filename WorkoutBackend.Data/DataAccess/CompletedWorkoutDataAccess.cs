namespace WorkoutBackend.Data.DataAccess;

public static class CompletedWorkoutDataAccess
{
    private static readonly string sqlFolder = "Sql/CompletedWorkouts";

    public static string GetAllCompletedWorkouts => DataAccessHelper.GetSqlString(sqlFolder, "GetAllCompletedWorkouts.sql");
    public static string GetCompletedWorkoutById => DataAccessHelper.GetSqlString(sqlFolder, "GetCompletedWorkoutById.sql");
    public static string InsertCompletedWorkout => DataAccessHelper.GetSqlString(sqlFolder, "InsertCompletedWorkout.sql");
    public static string UpdateComepletedWorkoutById => DataAccessHelper.GetSqlString(sqlFolder, "UpdateComepletedWorkoutById.sql");
    public static string DeleteCompletedWorkoutById => DataAccessHelper.GetSqlString(sqlFolder, "DeleteCompletedWorkoutById.sql");
}
