INSERT INTO Workouts (Name, Description, UserId, ProgramId)
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.ProgramId,
	INSERTED.UserId
VALUES (@Name, @Description, @UserId, NULL);