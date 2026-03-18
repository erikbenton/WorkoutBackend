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
WHERE CompletedWorkoutId = @CompletedWorkoutId
	AND UserId = @UserId;