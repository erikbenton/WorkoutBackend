SELECT Id, Reps, Weight, MinReps, MaxReps, SetTagId, Sort, CompletedExerciseGroupId, CreatedAt
FROM CompletedExerciseSets
WHERE CompletedExerciseGroupId = @CompletedExerciseGroupId;