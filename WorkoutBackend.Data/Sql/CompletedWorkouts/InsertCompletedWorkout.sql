INSERT INTO CompletedWorkouts
	(WorkoutId, Name, Note, DurationInSeconds)
OUTPUT
	INSERTED.Id,
	INSERTED.WorkoutId,
	INSERTED.Name,
	INSERTED.Note,
	INSERTED.DurationInSeconds,
	INSERTED.CreatedAt
VALUES (@WorkoutId, @Name, @Note, @DurationInSeconds);