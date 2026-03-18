INSERT INTO Workouts (Name, Description, ProgramId, UserId)
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.ProgramId,
	INSERTED.UserId
VALUES (@Name, @Description, @ProgramId, @UserId)