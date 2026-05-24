DELETE FROM Exercises
WHERE Id = @Id
	AND UserId = @UserId;