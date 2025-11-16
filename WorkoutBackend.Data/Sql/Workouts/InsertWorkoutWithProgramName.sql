INSERT INTO Workouts (Name, Description, ProgramId)
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.ProgramId
VALUES (@Name, @Description,
		(SELECT Id FROM Programs WHERE Name = @ProgramName))