SELECT
	cw.Id,
	CASE
		WHEN cw.WorkoutId IS NULL
		THEN cw.Name
		ELSE w.Name
	END AS Name,
	COUNT(ceg.Id) AS NumberOfExerciseGroups,
	cw.DurationInSeconds,
	cw.CreatedAt AS CompletedAt
FROM CompletedWorkouts cw
JOIN CompletedExerciseGroups ceg
ON ceg.CompletedWorkoutId = cw.Id
LEFT JOIN Workouts w
ON w.Id = cw.WorkoutId
GROUP BY cw.Id, cw.WorkoutId, cw.Name, w.Name, cw.DurationInSeconds, cw.CreatedAt;