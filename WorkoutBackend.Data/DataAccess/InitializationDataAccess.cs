namespace WorkoutBackend.Data.DataAccess;

public static class InitializationDataAccess
{
    private static readonly string sqlFolder = "Sql/Initialization";
    public static string DropAllTables => DataAccessHelper.GetSqlString(sqlFolder, "DropAllTables.sql");
    public static string InitializeTables => DataAccessHelper.GetSqlString(sqlFolder, "InitializeTables.sql");
    public static string PopulateBodyParts => DataAccessHelper.GetSqlString(sqlFolder, "PopulateBodyParts.sql");
    public static string PopulateEquipment => DataAccessHelper.GetSqlString(sqlFolder, "PopulateEquipment.sql");
    public static string PopulateExercises => DataAccessHelper.GetSqlString(sqlFolder, "PopulateExercises.sql");
    public static string PopulateTwoWorkouts => DataAccessHelper.GetSqlString(sqlFolder, "PopulateTwoWorkouts.sql");
}
