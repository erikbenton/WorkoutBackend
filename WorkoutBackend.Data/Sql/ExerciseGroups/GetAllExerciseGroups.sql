SELECT
	Id,
	Note,
	RestTimeInSeconds,
	Sort,
	ExerciseId,
	WorkoutId,
	UserId
FROM ExerciseGroups
WHERE UserId = @UserId;

SELECT
	Id,
	MinReps,
	MaxReps,
	SetTagId,
	Sort,
	ExerciseGroupId,
	UserId
FROM ExerciseSets exSets
WHERE exSets.UserId = @UserId;;