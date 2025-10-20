using WorkoutBackend.Data.Repositories;
using WorkoutBackend.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var workoutDbConnectionString = builder.Configuration.GetConnectionString("WorkoutDb")
    ?? throw new InvalidOperationException("Connection string 'WorkoutDb' not found.");

// Repos
builder.Services.AddScoped<IExerciseRepository, SqlExerciseRepository>(repo => new SqlExerciseRepository(workoutDbConnectionString));
builder.Services.AddScoped<IWorkoutRepository, SqlWorkoutRepository>(repo => new SqlWorkoutRepository(workoutDbConnectionString));
builder.Services.AddScoped<IExerciseGroupRepository, SqlExerciseGroupRepository>(repo => new SqlExerciseGroupRepository(workoutDbConnectionString));
builder.Services.AddScoped<IExerciseSetRepository, SqlExerciseSetRepository>(repo => new SqlExerciseSetRepository(workoutDbConnectionString));

// Workout services
builder.Services.AddScoped<IWorkoutSaver, SqlWorkoutSaver>();
builder.Services.AddScoped<IWorkoutRetriever, SqlWorkoutRetriever>();

//CORS
var workoutFrontEndCorsPolicy = "workoutFrontEndCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: workoutFrontEndCorsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(workoutFrontEndCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
