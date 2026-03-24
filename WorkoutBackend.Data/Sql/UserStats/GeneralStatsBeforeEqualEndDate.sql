SELECT
	COUNT(DISTINCT cw.Id) AS NumberOfWorkouts,
	ISNULL(SUM(cw.DurationInSeconds), 0) AS DurationInSeconds,
	COUNT(DISTINCT cg.ExerciseId) AS NumberOfExercises,
	ISNULL(SUM(DISTINCT cs.Id), 0) AS NumberOfSets,
	ISNULL(SUM(cs.Reps), 0) AS NumberOfReps,
	CAST(ISNULL(SUM(cs.Reps * ISNULL(cs.Weight, 1)), 0) AS INT) AS TotalVolume
FROM CompletedWorkouts cw
LEFT JOIN CompletedExerciseGroups cg
ON cg.CompletedWorkoutId = cw.Id
LEFT JOIN CompletedExerciseSets cs
ON cs.CompletedExerciseGroupId = cg.Id
WHERE cw.CreatedAt >= @EndDate
	AND cw.UserId = @UserId;