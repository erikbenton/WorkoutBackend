UPDATE Workouts
SET
	Name = @Name,
	Description = @Description,
	ProgramId = @ProgramId
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.ProgramId
WHERE Id = @Id