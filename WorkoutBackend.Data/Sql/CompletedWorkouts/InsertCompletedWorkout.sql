INSERT INTO CompletedWorkouts
	(Name, Description, ColorRgb, Tag, Note, DurationInSeconds, UserId)
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
VALUES (@Name, @Description, @ColorRgb, @Tag, @Note, @DurationInSeconds, @UserId);