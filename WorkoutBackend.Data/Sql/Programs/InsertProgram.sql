INSERT INTO Programs (Name, ColorRgb, Tag, Description, UserId)
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.ColorRgb,
	INSERTED.Tag,
	INSERTED.Description,
	INSERTED.UserId
VALUES (@Name, @ColorRgb, @Tag, @Description, @UserId)