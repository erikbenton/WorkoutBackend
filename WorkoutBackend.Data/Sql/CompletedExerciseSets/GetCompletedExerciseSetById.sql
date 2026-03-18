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
WHERE Id = @Id
	AND UserId = @UserId;