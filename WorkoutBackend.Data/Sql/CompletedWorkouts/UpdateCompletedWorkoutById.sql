UPDATE CompletedWorkouts
SET
	WorkoutId = @WorkoutId,
	Name = @Name,
	Note = @Note,
	DurationInSeconds = @DurationInSeconds,
	CreatedAt = @CreatedAt
OUTPUT
	UPDATED.Id,
	UPDATED.WorkoutId,
	UPDATED.Name,
	UPDATED.Note,
	UPDATED.DurationInSeconds,
	UPDATED.CreatedAt
WHERE Id = @Id;