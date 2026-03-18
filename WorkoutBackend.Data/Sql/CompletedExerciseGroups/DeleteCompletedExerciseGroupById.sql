DELETE FROM CompletedExerciseGroups
WHERE Id = @Id
	AND UserId = @UserId;