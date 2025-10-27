UPDATE CompletedExerciseSets
SET
	Reps = @Reps,
	Weight = @Weight,
	Sort = @Sort,
	CompletedExerciseGroupId = @CompletedExerciseGroupId
WHERE Id = @Id;