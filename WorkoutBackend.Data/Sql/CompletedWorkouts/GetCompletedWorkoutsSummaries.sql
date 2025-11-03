SELECT
	cw.Id,
	cw.Name,
	COUNT(ceg.Id) AS NumberOfExerciseGroups,
	cw.DurationInSeconds,
	cw.CreatedAt AS CompletedAt
FROM CompletedWorkouts cw
LEFT JOIN CompletedExerciseGroups ceg
ON ceg.CompletedWorkoutId = cw.Id
GROUP BY cw.Id, cw.WorkoutId, cw.Name, cw.DurationInSeconds, cw.CreatedAt
ORDER BY cw.CreatedAt DESC;