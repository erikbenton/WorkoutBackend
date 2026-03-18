SELECT Id, Note, RestTimeInSeconds, Sort, ExerciseId, WorkoutId, UserId
FROM ExerciseGroups
WHERE Id = @Id
	AND UserId = @UserId;