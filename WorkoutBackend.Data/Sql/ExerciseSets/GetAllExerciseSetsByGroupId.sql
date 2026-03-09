SELECT Id, MinReps, MaxReps, SetTagId, Sort, ExerciseGroupId
FROM ExerciseSets
WHERE ExerciseGroupId = @ExerciseGroupId
ORDER BY Sort ASC