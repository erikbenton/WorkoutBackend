SELECT
	Id,
	Reps,
	Weight,
	DurationInSeconds,
	DistanceInMiles,
	MinReps,
	MaxReps,
	TargetDurationInSeconds,
	TargetDistanceinMiles,
	SetTagId,
	Sort,
	CompletedExerciseGroupId,
	UserId,
	CreatedAt
FROM CompletedExerciseSets
WHERE CompletedExerciseGroupId = @CompletedExerciseGroupId
	AND UserId = @UserId;