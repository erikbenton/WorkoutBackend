SELECT
	COUNT(DISTINCT Id) AS NumberOfWorkouts,
	ISNULL(SUM(DurationInSeconds), 0) AS DurationInSeconds
FROM CompletedWorkouts
WHERE CreatedAt >= @EndDate
	AND UserId = @UserId;