SELECT
	ISNULL(COUNT(DISTINCT Id), 0) AS NumberOfSets,
	ISNULL(SUM(Reps), 0) AS NumberOfReps,
	CAST(ISNULL(SUM(Reps * ISNULL(Weight, 1)), 0) AS INT) AS TotalVolume
FROM CompletedExerciseSets
WHERE CreatedAt >= @EndDate
	AND UserId = @UserId;