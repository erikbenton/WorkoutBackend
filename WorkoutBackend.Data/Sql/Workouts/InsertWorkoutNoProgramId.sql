INSERT INTO Workouts (Name, Description, ColorRgb, Tag, UserId)
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.ColorRgb,
	INSERTED.Tag,
	INSERTED.UserId
VALUES (@Name, @Description, @ColorRgb, @Tag, @UserId);