namespace WorkoutBackend.Data.DataAccess;

public static class ExerciseGroupDataAccess
{
    private static readonly string sqlFolder = "Sql/ExerciseGroups";

    public static string GetExerciseGroupsByWorkoutId => DataAccessHelper.GetSqlString(sqlFolder, "GetExerciseGroupsByWorkoutId.sql");
    public static string GetExerciseGroupsByWorkoutName => DataAccessHelper.GetSqlString(sqlFolder, "GetExerciseGroupsByWorkoutName.sql");
    public static string GetExerciseGroupById => DataAccessHelper.GetSqlString(sqlFolder, "GetExerciseGroupById.sql");
    public static string InsertExerciseGroup => DataAccessHelper.GetSqlString(sqlFolder, "InsertExerciseGroup.sql");
    public static string UpdateExerciseGroupById => DataAccessHelper.GetSqlString(sqlFolder, "UpdateExerciseGroupById.sql");
    public static string DeleteExerciseGroupById => DataAccessHelper.GetSqlString(sqlFolder, "DeleteExerciseGroupById.sql");
}