SELECT Id, Note, RestTimeInSeconds, Sort, ExerciseId, WorkoutId, UserId
FROM ExerciseGroups
WHERE WorkoutId = @WorkoutId
	AND UserId = @UserId
ORDER BY Sort ASC