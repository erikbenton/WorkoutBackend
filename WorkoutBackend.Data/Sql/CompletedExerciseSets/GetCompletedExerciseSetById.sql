SELECT Id, Reps, Weight, Sort, CompletedExerciseGroupId
FROM CompletedExerciseSets
WHERE Id = @Id;