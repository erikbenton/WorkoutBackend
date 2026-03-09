SELECT
	Id,
	Note,
	Comment,
	RestTimeInSeconds,
	Sort,
	ExerciseId,
	CompletedWorkoutId,
	CreatedAt
FROM CompletedExerciseGroups;

SELECT
	Id,
	Reps,
	Weight,
	MinReps,
	MaxReps,
	SetTagId,
	Sort,
	CompletedExerciseGroupId,
	CreatedAt
FROM CompletedExerciseSets;