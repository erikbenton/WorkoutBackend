namespace WorkoutBackend.Data.DataAccess;

public static class CompletedExerciseGroupsDataAccess
{
    private static readonly string sqlFolder = "Sql/CompletedExerciseGroups";

    public static string GetCompletedExerciseGroupsByCompletedWorkoutId => DataAccessHelper.GetSqlString(sqlFolder, "GetCompletedExerciseGroupsByCompletedWorkoutId.sql");
    public static string GetCompletedExerciseGroupById => DataAccessHelper.GetSqlString(sqlFolder, "GetCompletedExerciseGroupById.sql");
    public static string InsertCompletedExerciseGroup => DataAccessHelper.GetSqlString(sqlFolder, "InsertCompletedExerciseGroup.sql");
    public static string UpdateCompletedExerciseGroupById => DataAccessHelper.GetSqlString(sqlFolder, "UpdateCompletedExerciseGroupById.sql");
    public static string DeleteCompletedExerciseGroupById => DataAccessHelper.GetSqlString(sqlFolder, "DeleteCompletedExerciseGroupById.sql");
}