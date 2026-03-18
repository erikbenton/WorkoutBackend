SELECT
	ceg.Id AS CompletedExerciseGroupId,
	DATEPART(YEAR, ceg.CreatedAt) AS Year,
	DATEPART(MONTH, ceg.CreatedAt) AS Month,
	DATEPART(DAY, ceg.CreatedAt) AS Day,
	ceg.Comment AS Comment,
	ceg.ExerciseId AS ExerciseId,
	ceg.UserId
FROM CompletedExerciseGroups ceg
WHERE ceg.ExerciseId = @ExerciseId
	AND ceg.UserId = @UserId
ORDER BY ceg.CreatedAt DESC;