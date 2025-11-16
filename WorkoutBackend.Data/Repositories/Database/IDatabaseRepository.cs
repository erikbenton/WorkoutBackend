namespace WorkoutBackend.Data.Repositories.Database;

public interface IDatabaseRepository
{
    public Task DropAllTablesAsync();
    public Task CreateAllTablesAsync();
    public Task PopulateSupportValues();
    public Task SeedData();
}
