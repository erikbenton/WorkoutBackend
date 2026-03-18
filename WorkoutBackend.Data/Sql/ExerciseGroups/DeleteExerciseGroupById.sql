DELETE FROM ExerciseGroups
WHERE Id = @Id
	AND UserId = @UserId;