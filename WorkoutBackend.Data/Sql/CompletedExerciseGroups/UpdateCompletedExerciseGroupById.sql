UPDATE CompletedExerciseGroups
SET
	Note = @Note,
	Comment = @Comment,
	Sort = @Sort,
	ExerciseId = @ExerciseId,
	CompletedWorkoutId = @CompletedWorkoutId,
	CreatedAt = @CreatedAt
OUTPUT
	INSERTED.Id,
	INSERTED.Note,
	INSERTED.Comment,
	INSERTED.Sort,
	INSERTED.ExerciseId,
	INSERTED.CompletedWorkoutId,
	INSERTED.CreatedAt
WHERE Id = @Id;