SELECT Id, Reps, Weight, MinReps, MaxReps, SetType, Sort, CompletedExerciseGroupId, CreatedAt
FROM CompletedExerciseSets
WHERE CompletedExerciseGroupId = @CompletedExerciseGroupId;