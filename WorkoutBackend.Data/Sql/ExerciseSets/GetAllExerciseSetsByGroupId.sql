SELECT Id, Reps, Weight, Sort, ExerciseGroupId
FROM ExerciseSets
WHERE ExerciseGroupId = @ExerciseGroupId
ORDER BY Sort ASC