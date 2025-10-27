namespace WorkoutBackend.Data.DataAccess;

public static class CompletedExerciseSetsDataAccess
{
    private static readonly string sqlFolder = "Sql/CompletedExerciseSets";

    public static string GetCompletedExerciseSetsByCompletedGroupId => DataAccessHelper.GetSqlString(sqlFolder, "GetCompletedExerciseSetsByCompletedGroupId.sql");
    public static string GetCompletedExerciseSetById => DataAccessHelper.GetSqlString(sqlFolder, "GetCompletedExerciseSetById.sql");
    public static string InsertCompletedExerciseSet => DataAccessHelper.GetSqlString(sqlFolder, "InsertCompletedExerciseSet.sql");
    public static string UpdateCompletedExerciseSetById => DataAccessHelper.GetSqlString(sqlFolder, "UpdateCompletedExerciseSetById.sql");
    public static string DeleteCompletedExerciseSetById => DataAccessHelper.GetSqlString(sqlFolder, "DeleteCompletedExerciseSetById.sql");
}