UPDATE CompletedWorkouts
SET
	Name = @Name,
	Description = @Description,
	ColorRgb = @ColorRgb,
	Tag = @Tag,
	Note = @Note,
	DurationInSeconds = @DurationInSeconds,
	CreatedAt = @CreatedAt,
	UserId = @UserId
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.ColorRgb,
	INSERTED.Tag,
	INSERTED.Note,
	INSERTED.DurationInSeconds,
	INSERTED.UserId,
	INSERTED.CreatedAt
WHERE Id = @Id
	AND UserId = @UserId;