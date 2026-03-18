DELETE FROM ExerciseSets
WHERE Id = @Id
	AND UserId = @UserId;