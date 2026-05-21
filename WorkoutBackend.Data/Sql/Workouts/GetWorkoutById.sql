SELECT Id, Name, Description, UserId
FROM Workouts
WHERE Id = @Id
	AND UserId = @UserId;