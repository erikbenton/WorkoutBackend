UPDATE Programs SET
	Name = @Name,
	ColorRgb = @ColorRgb,
	Description = @Description
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.ColorRgb,
	INSERTED.Description,
	INSERTED.UserId
WHERE Id = @Id
	AND UserId = @UserId;