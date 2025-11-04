SELECT Id, Note, RestTimeInSeconds, Sort, ExerciseId, WorkoutId
FROM ExerciseGroups
WHERE WorkoutId = @WorkoutId
ORDER BY Sort ASC