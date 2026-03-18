INSERT INTO CompletedWorkouts
	(Name, Description, Note, DurationInSeconds, UserId)
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.Note,
	INSERTED.DurationInSeconds,
	INSERTED.UserId,
	INSERTED.CreatedAt
VALUES (@Name, @Description, @Note, @DurationInSeconds, @UserId);