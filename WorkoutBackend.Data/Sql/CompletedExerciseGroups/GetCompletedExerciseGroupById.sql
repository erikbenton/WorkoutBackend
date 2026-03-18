SELECT
	Id,
	Note,
	Comment,
	RestTimeInSeconds,
	Sort,
	ExerciseId,
	CompletedWorkoutId,
	UserId,
	CreatedAt
FROM CompletedExerciseGroups
WHERE Id = @Id
	AND UserId = @UserId;