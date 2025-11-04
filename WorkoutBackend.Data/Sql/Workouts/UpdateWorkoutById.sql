UPDATE Workouts
SET
	Name = @Name,
	ProgramId = @ProgramId
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.ProgramId
WHERE Id = @Id