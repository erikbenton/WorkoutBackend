UPDATE CompletedExerciseGroups
SET
	Note = @Note,
	Sort = @Sort,
	ExerciseId = @ExerciseId,
	CompletedWorkoutId = @CompletedWorkoutId,
	CreatedAt = @CreatedAt
OUTPUT
	UPDATED.Id,
	UPDATED.Note,
	UPDATED.Sort,
	UPDATED.ExerciseId,
	UPDATED.CompletedWorkoutId,
	UPDATED.CreatedAt
WHERE Id = @Id;