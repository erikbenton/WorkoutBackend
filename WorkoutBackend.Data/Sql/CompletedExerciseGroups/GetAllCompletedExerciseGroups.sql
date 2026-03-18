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
	MinReps,
	MaxReps,
	SetTagId,
	Sort,
	CompletedExerciseGroupId,
	UserId,
	CreatedAt
FROM CompletedExerciseSets
WHERE UserId = @UserId;