SELECT
	Id,
	Reps,
	Weight,
	DurationInSeconds,
	DistanceInMiles,
	MinReps,
	MaxReps,
	TargetDurationInSeconds,
	TargetDistanceInMiles,
	SetTagId,
	Sort,
	CompletedExerciseGroupId,
	UserId,
	CreatedAt
FROM CompletedExerciseSets
WHERE Id = @Id
	AND UserId = @UserId;