SELECT Id, Note, Sort, ExerciseId, CompletedWorkoutId
FROM CompletedExerciseGroups
WHERE Id = @Id;