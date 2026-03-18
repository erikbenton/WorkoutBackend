INSERT INTO Workouts (Name, Description, UserId, ProgramId)
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.ProgramId,
	INSERTED.UserId
VALUES (@Name, @Description, @UserId,
		(SELECT Id FROM Programs WHERE Name = @ProgramName));