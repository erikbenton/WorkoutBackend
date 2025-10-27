SELECT Id, Note, Sort, ExerciseId, CompletedWorkoutId
FROM CompletedExerciseGroups
WHERE CompletedWorkoutId = @CompletedWorkoutId;