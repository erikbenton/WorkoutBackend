UPDATE CompletedWorkouts
SET
	Name = @Name,
	Description = @Description,
	Note = @Note,
	DurationInSeconds = @DurationInSeconds,
	CreatedAt = @CreatedAt,
	UserId = @UserId
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.Note,
	INSERTED.DurationInSeconds,
	INSERTED.UserId,
	INSERTED.CreatedAt
WHERE Id = @Id
	AND UserId = @UserId;