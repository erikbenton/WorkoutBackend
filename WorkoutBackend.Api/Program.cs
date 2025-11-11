using WorkoutBackend.Data.Repositories.CompletedWorkouts;
using WorkoutBackend.Data.Repositories.Database;
using WorkoutBackend.Data.Repositories.Exercises;
using WorkoutBackend.Data.Repositories.Workouts;
using WorkoutBackend.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Database connection string
var workoutDbConnectionString = builder.Configuration.GetConnectionString("WorkoutDb")
    ?? throw new InvalidOperationException("Connection string 'WorkoutDb' not found.");

// Repos
builder.Services.AddScoped<IExerciseRepository, SqlExerciseRepository>(repo => new SqlExerciseRepository(workoutDbConnectionString));
builder.Services.AddScoped<IWorkoutRepository, SqlWorkoutRepository>(repo => new SqlWorkoutRepository(workoutDbConnectionString));
builder.Services.AddScoped<IExerciseGroupRepository, SqlExerciseGroupRepository>(repo => new SqlExerciseGroupRepository(workoutDbConnectionString));
builder.Services.AddScoped<IExerciseSetRepository, SqlExerciseSetRepository>(repo => new SqlExerciseSetRepository(workoutDbConnectionString));

builder.Services.AddScoped<ICompletedWorkoutRepository, SqlCompletedWorkoutRepository>(repo => new SqlCompletedWorkoutRepository(workoutDbConnectionString));
builder.Services.AddScoped<ICompletedExerciseGroupRepository, SqlCompletedExerciseGroupRepository>(repo => new SqlCompletedExerciseGroupRepository(workoutDbConnectionString));
builder.Services.AddScoped<ICompletedExerciseSetRepository, SqlCompletedExerciseSetRepository>(repo => new SqlCompletedExerciseSetRepository(workoutDbConnectionString));

builder.Services.AddScoped<IDatabaseRepository, SqlDatabaseRepository>(repo => new SqlDatabaseRepository(workoutDbConnectionString));

// Workout services
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<ICompletedWorkoutService, CompletedWorkoutService>();

//CORS
var workoutFrontEndCorsPolicy = "workoutFrontEndCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: workoutFrontEndCorsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(workoutFrontEndCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
