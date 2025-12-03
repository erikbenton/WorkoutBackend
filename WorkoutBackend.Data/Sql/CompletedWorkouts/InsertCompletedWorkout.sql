INSERT INTO CompletedWorkouts
	(WorkoutId, Name, Description, Note, DurationInSeconds)
OUTPUT
	INSERTED.Id,
	INSERTED.WorkoutId,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.Note,
	INSERTED.DurationInSeconds,
	INSERTED.CreatedAt
VALUES (@WorkoutId, @Name, @Description, @Note, @DurationInSeconds);