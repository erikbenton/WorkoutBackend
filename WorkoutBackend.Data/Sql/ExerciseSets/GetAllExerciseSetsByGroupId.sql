SELECT Id, MinReps, MaxReps, SetType, Sort, ExerciseGroupId
FROM ExerciseSets
WHERE ExerciseGroupId = @ExerciseGroupId
ORDER BY Sort ASC