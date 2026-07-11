UPDATE Programs SET
	Name = @Name,
	ColorRgb = @ColorRgb,
	Tag = @Tag,
	Description = @Description
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.ColorRgb,
	INSERTED.Tag,
	INSERTED.Description,
	INSERTED.UserId
WHERE Id = @Id
	AND UserId = @UserId;