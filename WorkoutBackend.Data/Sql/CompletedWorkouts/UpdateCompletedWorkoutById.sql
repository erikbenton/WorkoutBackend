UPDATE CompletedWorkouts
SET
	WorkoutId = @WorkoutId,
	Name = @Name,
	Note = @Note,
	DurationInSeconds = @DurationInSeconds,
	CreatedAt = @CreatedAt
WHERE Id = @Id;