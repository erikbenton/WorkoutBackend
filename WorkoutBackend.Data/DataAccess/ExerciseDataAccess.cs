namespace WorkoutBackend.Data.DataAccess;

public static class ExerciseDataAccess
{
    private static readonly string sqlFolder = "Sql/Exercises";
    public static string GetAllExercises => DataAccessHelper.GetSqlString(sqlFolder, "GetAllExercisesWithDetails.sql");
    public static string GetExercisesByName => DataAccessHelper.GetSqlString(sqlFolder, "GetExercisesByName.sql");
    public static string GetExerciseById => DataAccessHelper.GetSqlString(sqlFolder, "GetExerciseById.sql");
    public static string InsertExerciseWithDetails => DataAccessHelper.GetSqlString(sqlFolder, "InsertExerciseWithDetails.sql");
    public static string UpdateExerciseWithDetails => DataAccessHelper.GetSqlString(sqlFolder, "UpdateExerciseWithDetails.sql");
    public static string DeleteExerciseById => DataAccessHelper.GetSqlString(sqlFolder, "DeleteExerciseById.sql");
    public static string GetAllExerciseBodyPartOptions => DataAccessHelper.GetSqlString(sqlFolder, "GetAllExerciseBodyPartOptions.sql");
    public static string GetAllExerciseEquipmentOptions => DataAccessHelper.GetSqlString(sqlFolder, "GetAllExerciseEquipmentOptions.sql");
}
