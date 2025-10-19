using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Data.DataAccess;

namespace WorkoutBackend.IntegrationTests.Helpers;

public static class WorkoutHelper
{
    public static async Task InitializeWorkouts()
    {
        using var connection = new SqlConnection(DatabaseHelper.TestConnectionString);
        await connection.ExecuteAsync(InitializationDataAccess.PopulateTwoWorkouts);
    }
}