namespace WorkoutBackend.Data.DataAccess;

public static class ProgramDataAccess
{
    private static readonly string sqlFolder = "/Sql/Programs";

    public static string GetAllProgramsWithWorkoutIds => DataAccessHelper.GetSqlString(sqlFolder, "GetAllProgramsWithWorkoutIds.sql");
    public static string GetAllProgramWorkoutsByProgramId => DataAccessHelper.GetSqlString(sqlFolder, "GetAllProgramWorkoutsByProgramId.sql");
    public static string InsertProgram => DataAccessHelper.GetSqlString(sqlFolder, "InsertProgram.sql");
    public static string InsertProgramWorkout => DataAccessHelper.GetSqlString(sqlFolder, "InsertProgramWorkout.sql");
    public static string UpdateProgram => DataAccessHelper.GetSqlString(sqlFolder, "UpdateProgram.sql");
    public static string DeleteProgram => DataAccessHelper.GetSqlString(sqlFolder, "DeleteProgram.sql");
    public static string DeleteProgramWorkoutsByProgramId => DataAccessHelper.GetSqlString(sqlFolder, "DeleteProgramWorkoutsByProgramId.sql");
}
