SELECT Id, Name, Description, ColorRgb, Tag, UserId
FROM Workouts
WHERE Id = @Id
	AND UserId = @UserId;