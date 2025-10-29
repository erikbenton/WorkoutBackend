SELECT Id, Note, Sort, ExerciseId, CompletedWorkoutId, CreatedAt
FROM CompletedExerciseGroups
WHERE CompletedWorkoutId = @CompletedWorkoutId;