SELECT Id, Note, Comment, RestTimeInSeconds, Sort, ExerciseId, CompletedWorkoutId, CreatedAt
FROM CompletedExerciseGroups
WHERE Id = @Id;