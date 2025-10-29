SELECT
	cw.Id,
	cw.WorkoutId,
	CASE
		WHEN cw.WorkoutId IS NULL
		THEN cw.Name
		ELSE w.Name
	END AS Name,
	cw.Note,
	cw.DurationInSeconds,
	cw.CreatedAt
FROM CompletedWorkouts cw
LEFT JOIN Workouts w
ON w.Id = cw.WorkoutId