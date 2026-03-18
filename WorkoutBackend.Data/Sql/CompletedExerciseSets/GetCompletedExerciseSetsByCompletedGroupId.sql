SELECT
	Id,
	Reps,
	Weight,
	MinReps,
	MaxReps,
	SetTagId,
	Sort,
	CompletedExerciseGroupId,
	UserId,
	CreatedAt
FROM CompletedExerciseSets
WHERE CompletedExerciseGroupId = @CompletedExerciseGroupId
	AND UserId = @UserId;