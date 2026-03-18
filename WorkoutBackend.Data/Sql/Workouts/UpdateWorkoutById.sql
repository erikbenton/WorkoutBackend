UPDATE Workouts
SET
	Name = @Name,
	Description = @Description,
	ProgramId = @ProgramId,
	UserId = @UserId
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.ProgramId,
	INSERTED.UserId
WHERE Id = @Id
	AND UserId = @UserId;