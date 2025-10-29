UPDATE CompletedExerciseSets
SET
	Reps = @Reps,
	Weight = @Weight,
	Sort = @Sort,
	CompletedExerciseGroupId = @CompletedExerciseGroupId,
	CreatedAt = @CreatedAt
OUTPUT
	UPDATED.Id,
	UPDATED.Reps,
	UPDATED.Weight,
	UPDATED.Sort,
	UPDATED.CompletedExerciseGroupId,
	UPDATED.CreatedAt
WHERE Id = @Id;