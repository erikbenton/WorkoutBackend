using WorkoutBackend.Data.Repositories.CompletedWorkouts;
using WorkoutBackend.Data.Repositories.Database;
using WorkoutBackend.Data.Repositories.Exercises;
using WorkoutBackend.Data.Repositories.UserStats;
using WorkoutBackend.Data.Repositories.Workouts;
using WorkoutBackend.Data.Services;
using WorkoutBackend.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Database connection string
var workoutDbConnectionString = builder.Configuration.GetConnectionString("WorkoutDb")
    ?? throw new InvalidOperationException("Connection string 'WorkoutDb' not found.");

// add the EF Core identity context for handling users
builder.Services.AddIdentityContext(workoutDbConnectionString);

// Repos
builder.Services.AddScoped<IExerciseRepository, SqlExerciseRepository>(repo => new SqlExerciseRepository(workoutDbConnectionString));
builder.Services.AddScoped<IWorkoutRepository, SqlWorkoutRepository>(repo => new SqlWorkoutRepository(workoutDbConnectionString));
builder.Services.AddScoped<IExerciseGroupRepository, SqlExerciseGroupRepository>(repo => new SqlExerciseGroupRepository(workoutDbConnectionString));
builder.Services.AddScoped<IExerciseSetRepository, SqlExerciseSetRepository>(repo => new SqlExerciseSetRepository(workoutDbConnectionString));

builder.Services.AddScoped<ICompletedWorkoutRepository, SqlCompletedWorkoutRepository>(repo => new SqlCompletedWorkoutRepository(workoutDbConnectionString));
builder.Services.AddScoped<ICompletedExerciseGroupRepository, SqlCompletedExerciseGroupRepository>(repo => new SqlCompletedExerciseGroupRepository(workoutDbConnectionString));
builder.Services.AddScoped<ICompletedExerciseSetRepository, SqlCompletedExerciseSetRepository>(repo => new SqlCompletedExerciseSetRepository(workoutDbConnectionString));

builder.Services.AddScoped<IUserStatsRepository, SqlUserStatsRepository>(repo => new SqlUserStatsRepository(workoutDbConnectionString));

builder.Services.AddScoped<IDatabaseRepository, SqlDatabaseRepository>(repo => new SqlDatabaseRepository(workoutDbConnectionString));

// Workout services
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<ICompletedWorkoutService, CompletedWorkoutService>();
builder.Services.AddScoped<IUserStatsService, UserStatsService>();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();
app.UseAuthentication();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
