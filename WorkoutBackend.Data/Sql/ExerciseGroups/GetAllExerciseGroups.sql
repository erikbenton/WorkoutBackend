SELECT
	Id,
	Note,
	RestTimeInSeconds,
	Sort,
	ExerciseId,
	WorkoutId
FROM ExerciseGroups;

SELECT
	Id,
	MinReps,
	MaxReps,
	SetTagId,
	Sort,
	ExerciseGroupId
FROM ExerciseSets exSets;