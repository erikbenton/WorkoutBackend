INSERT INTO Programs (Name, ColorRgb, Description, UserId)
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.ColorRgb,
	INSERTED.Description,
	INSERTED.UserId
VALUES (@Name, @ColorRgb, @Description, @UserId)