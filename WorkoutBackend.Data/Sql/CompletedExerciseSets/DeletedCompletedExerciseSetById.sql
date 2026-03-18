DELETE FROM CompletedExerciseSets
WHERE Id = @Id
	AND UserId = @UserId;