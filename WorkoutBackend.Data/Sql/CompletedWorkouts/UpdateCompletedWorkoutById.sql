UPDATE CompletedWorkouts
SET
	WorkoutId = @WorkoutId,
	Name = @Name,
	Note = @Note,
	DurationInSeconds = @DurationInSeconds,
	CreatedAt = @CreatedAt
OUTPUT
	INSERTED.Id,
	INSERTED.WorkoutId,
	INSERTED.Name,
	INSERTED.Note,
	INSERTED.DurationInSeconds,
	INSERTED.CreatedAt
WHERE Id = @Id;