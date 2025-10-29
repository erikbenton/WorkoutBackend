SELECT Id, Reps, Weight, Sort, CompletedExerciseGroupId, CreatedAt
FROM CompletedExerciseSets
WHERE CompletedExerciseGroupId = @CompletedExerciseGroupId;