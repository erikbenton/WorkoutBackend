INSERT INTO Workouts (Name, ProgramId)
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.ProgramId
VALUES (@Name,
		(SELECT Id FROM Programs WHERE Name = @ProgramName))