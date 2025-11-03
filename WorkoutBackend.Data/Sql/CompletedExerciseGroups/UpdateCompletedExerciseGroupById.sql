UPDATE CompletedExerciseGroups
SET
	Note = @Note,
	Comment = @Comment,
	Sort = @Sort,
	ExerciseId = @ExerciseId,
	CompletedWorkoutId = @CompletedWorkoutId,
	CreatedAt = @CreatedAt
OUTPUT
	UPDATED.Id,
	UPDATED.Note,
	UPDATED.Comment,
	UPDATED.Sort,
	UPDATED.ExerciseId,
	UPDATED.CompletedWorkoutId,
	UPDATED.CreatedAt
WHERE Id = @Id;