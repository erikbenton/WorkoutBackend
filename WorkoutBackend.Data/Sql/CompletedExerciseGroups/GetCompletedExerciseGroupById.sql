SELECT Id, Note, Sort, ExerciseId, CompletedWorkoutId, CreatedAt
FROM CompletedExerciseGroups
WHERE Id = @Id;