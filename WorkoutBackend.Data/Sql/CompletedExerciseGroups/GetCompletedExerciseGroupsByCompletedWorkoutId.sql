SELECT Id, Note, Comment, Sort, ExerciseId, CompletedWorkoutId, CreatedAt
FROM CompletedExerciseGroups
WHERE CompletedWorkoutId = @CompletedWorkoutId;