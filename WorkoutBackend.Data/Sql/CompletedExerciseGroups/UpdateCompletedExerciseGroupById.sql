UPDATE CompletedExerciseGroups
SET
	Note = @Note,
	Comment = @Comment,
	RestTimeInSeconds = @RestTimeInSeconds,
	Sort = @Sort,
	ExerciseId = @ExerciseId,
	CompletedWorkoutId = @CompletedWorkoutId,
	CreatedAt = @CreatedAt
OUTPUT
	INSERTED.Id,
	INSERTED.Note,
	INSERTED.Comment,
	INSERTED.RestTimeInSeconds,
	INSERTED.Sort,
	INSERTED.ExerciseId,
	INSERTED.CompletedWorkoutId,
	INSERTED.CreatedAt
WHERE Id = @Id;