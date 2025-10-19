INSERT INTO Workouts (Name, ProgramId)
OUTPUT INSERTED.Id
VALUES (@Name,
		(SELECT Id FROM Programs WHERE Name = @ProgramName))