using Microsoft.AspNetCore.HttpLogging;
using WorkoutBackend.Api.Loggers;
using WorkoutBackend.Data.Repositories.CompletedWorkouts;
using WorkoutBackend.Data.Repositories.Database;
using WorkoutBackend.Data.Repositories.Exercises;
using WorkoutBackend.Data.Repositories.Programs;
using WorkoutBackend.Data.Repositories.Users;
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

// Configure HTTP logging settings
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields =
        HttpLoggingFields.RequestPath |
        HttpLoggingFields.RequestBody |
        HttpLoggingFields.ResponseStatusCode |
        HttpLoggingFields.ResponseBody |
        HttpLoggingFields.Duration;
    logging.MediaTypeOptions.AddText("application/json");
    logging.MediaTypeOptions.AddText("text/plain");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});

// redact important/sensitive data from authentication requests
builder.Services.AddHttpLoggingInterceptor<AuthDataRedactingInterceptor>();

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

builder.Services.AddScoped<IProgramRepository, SqlProgramRepository>(repo => new SqlProgramRepository(workoutDbConnectionString));

builder.Services.AddScoped<IUserStatsRepository, SqlUserStatsRepository>(repo => new SqlUserStatsRepository(workoutDbConnectionString));
builder.Services.AddScoped<IUserInfoRepository, SqlUserInfoRepository>(repo => new SqlUserInfoRepository(workoutDbConnectionString));

builder.Services.AddScoped<IDatabaseRepository, SqlDatabaseRepository>(repo => new SqlDatabaseRepository(workoutDbConnectionString));

// Workout services
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<ICompletedWorkoutService, CompletedWorkoutService>();
builder.Services.AddScoped<IWorkoutProgramService, WorkoutProgramService>();
builder.Services.AddScoped<IUserStatsService, UserStatsService>();
builder.Services.AddScoped<IUserInfoService, UserInfoService>();

var app = builder.Build();

app.UseHttpLogging();
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
