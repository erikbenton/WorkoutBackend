DELETE FROM CompletedWorkouts
WHERE Id = @Id
	AND UserId = @UserId;