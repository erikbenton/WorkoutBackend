SELECT Id, Note, Sort, ExerciseId, WorkoutId
FROM ExerciseGroups
WHERE WorkoutId = @WorkoutId
ORDER BY Sort ASC