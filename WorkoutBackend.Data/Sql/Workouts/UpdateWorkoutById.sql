UPDATE Workouts
SET
	Name = @Name,
	Description = @Description,
	ColorRgb = @ColorRgb,
	Tag = @Tag,
	UserId = @UserId
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.ColorRgb,
	INSERTED.Tag,
	INSERTED.UserId
WHERE Id = @Id
	AND UserId = @UserId;