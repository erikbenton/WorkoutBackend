using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Data.DataAccess;

namespace WorkoutBackend.IntegrationTests.Helpers;

public static class ExerciseHelper
{
    public static async Task InitializeExercises()
    {
        using var connection = new SqlConnection(DatabaseHelper.TestConnectionString);
        await connection.ExecuteAsync(InitializationDataAccess.PopulateExercises);
    }
}
