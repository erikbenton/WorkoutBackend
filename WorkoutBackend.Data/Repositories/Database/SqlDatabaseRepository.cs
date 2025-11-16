
using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Data.DataAccess;

namespace WorkoutBackend.Data.Repositories.Database;

public class SqlDatabaseRepository(string connectionString) : IDatabaseRepository
{
    private readonly string _connectionString = connectionString;

    public async Task CreateAllTablesAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(InitializationDataAccess.InitializeTables);
    }

    public async Task DropAllTablesAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(InitializationDataAccess.DropAllTables);
    }

    public async Task PopulateSupportValues()
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(InitializationDataAccess.PopulateBodyParts);
        await connection.ExecuteAsync(InitializationDataAccess.PopulateEquipment);
    }

    public async Task SeedData()
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(InitializationDataAccess.PopulateExercises);
        await connection.ExecuteAsync(InitializationDataAccess.PopulateTwoWorkouts);
    }
}
