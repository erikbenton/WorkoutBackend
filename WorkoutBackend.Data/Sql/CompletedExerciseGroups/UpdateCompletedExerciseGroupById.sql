UPDATE CompletedExerciseGroups
SET
	Note = @Note,
	Sort = @Sort,
	ExerciseId = @ExerciseId,
	CompletedWorkoutId = @CompletedWorkoutId
WHERE Id = @Id;