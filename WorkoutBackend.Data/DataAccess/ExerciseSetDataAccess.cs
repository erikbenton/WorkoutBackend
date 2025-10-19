namespace WorkoutBackend.Data.DataAccess;

public static class ExerciseSetDataAccess
{
    private static readonly string sqlFolder = "Sql/ExerciseSets";

    public static string GetAllExerciseSetsByGroupId => DataAccessHelper.GetSqlString(sqlFolder, "GetAllExerciseSetsByGroupId.sql");
    public static string GetExerciseSetById => DataAccessHelper.GetSqlString(sqlFolder, "GetExerciseSetById.sql");
    public static string InsertExerciseSet => DataAccessHelper.GetSqlString(sqlFolder, "InsertExerciseSet.sql");
    public static string UpdateExerciseSetById => DataAccessHelper.GetSqlString(sqlFolder, "UpdateExerciseSetById.sql");
    public static string DeleteExerciseSetById => DataAccessHelper.GetSqlString(sqlFolder, "DeleteExerciseSetById.sql");
}

