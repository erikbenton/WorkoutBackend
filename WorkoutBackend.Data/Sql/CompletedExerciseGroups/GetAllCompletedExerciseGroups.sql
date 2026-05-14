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
WHERE UserId = @UserId;

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
WHERE UserId = @UserId;