SELECT Id, Name, Description, ProgramId, UserId
FROM Workouts
WHERE Id = @Id
	AND UserId = @UserId;