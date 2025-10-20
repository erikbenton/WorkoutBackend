SELECT Id, MinReps, MaxReps, Weight, Sort, ExerciseGroupId
FROM ExerciseSets
WHERE ExerciseGroupId = @ExerciseGroupId
ORDER BY Sort ASC