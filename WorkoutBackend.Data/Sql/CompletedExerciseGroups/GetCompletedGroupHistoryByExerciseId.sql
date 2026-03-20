SELECT
	ceg.Id AS CompletedExerciseGroupId,
	ceg.Comment AS Comment,
	ceg.ExerciseId AS ExerciseId,
	ceg.UserId,
	ceg.CreatedAt AS CreatedAt
FROM CompletedExerciseGroups ceg
WHERE ceg.ExerciseId = @ExerciseId
	AND ceg.UserId = @UserId
ORDER BY ceg.CreatedAt DESC;