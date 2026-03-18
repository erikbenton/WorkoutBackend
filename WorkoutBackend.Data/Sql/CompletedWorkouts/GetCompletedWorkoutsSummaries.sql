SELECT
	cw.Id,
	cw.Name,
	COUNT(ceg.Id) AS NumberOfExerciseGroups,
	cw.DurationInSeconds,
	cw.CreatedAt AS CompletedAt,
	cw.UserId
FROM CompletedWorkouts cw
LEFT JOIN CompletedExerciseGroups ceg
ON ceg.CompletedWorkoutId = cw.Id
WHERE cw.UserId = @UserId
GROUP BY cw.Id, cw.Name, cw.DurationInSeconds, cw.CreatedAt
ORDER BY cw.CreatedAt DESC;