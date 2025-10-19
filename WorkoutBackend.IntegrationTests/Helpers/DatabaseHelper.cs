using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Data.DataAccess;

namespace WorkoutBackend.IntegrationTests.Helpers;

public static class DatabaseHelper
{
    public static readonly string SqlFileLocation = "Helpers/Sql";

    public static readonly string TestConnectionString = new SqlConnectionStringBuilder
    {
        DataSource = "(localdb)\\MSSQLLocalDB",
        InitialCatalog = "TestWorkoutDb",
        IntegratedSecurity = true,
        TrustServerCertificate = false,
        ConnectTimeout = 30
    }.ConnectionString;

    public static async Task RefreshDatabase()
    {
        using var connection = new SqlConnection(TestConnectionString);
        await connection.ExecuteAsync(InitializationDataAccess.DropAllTables);
        await connection.ExecuteAsync(InitializationDataAccess.InitializeTables);
        await connection.ExecuteAsync(InitializationDataAccess.PopulateBodyParts);
        await connection.ExecuteAsync(InitializationDataAccess.PopulateEquipment);
    }
}
