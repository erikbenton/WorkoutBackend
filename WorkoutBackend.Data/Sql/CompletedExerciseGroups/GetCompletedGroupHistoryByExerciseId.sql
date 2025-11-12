SELECT
	ceg.Id AS CompletedExerciseGroupId,
	DATEPART(YEAR, ceg.CreatedAt) AS Year,
	DATEPART(MONTH, ceg.CreatedAt) AS Month,
	DATEPART(DAY, ceg.CreatedAt) AS Day,
	ceg.ExerciseId AS ExerciseId
FROM CompletedExerciseGroups ceg
WHERE ceg.ExerciseId = @ExerciseId
ORDER BY ceg.CreatedAt DESC;