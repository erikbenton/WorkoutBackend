UPDATE CompletedWorkouts
SET
	WorkoutId = @WorkoutId,
	Name = @Name,
	Description = @Description,
	Note = @Note,
	DurationInSeconds = @DurationInSeconds,
	CreatedAt = @CreatedAt
OUTPUT
	INSERTED.Id,
	INSERTED.WorkoutId,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.Note,
	INSERTED.DurationInSeconds,
	INSERTED.CreatedAt
WHERE Id = @Id;