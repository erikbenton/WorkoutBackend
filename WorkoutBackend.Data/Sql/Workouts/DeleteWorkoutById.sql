DELETE FROM Workouts
WHERE Id = @Id
	AND UserId = @UserId;