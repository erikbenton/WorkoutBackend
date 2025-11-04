UPDATE CompletedExerciseSets
SET
	Reps = @Reps,
	Weight = @Weight,
	Sort = @Sort,
	CompletedExerciseGroupId = @CompletedExerciseGroupId,
	CreatedAt = @CreatedAt
OUTPUT
	INSERTED.Id,
	INSERTED.Reps,
	INSERTED.Weight,
	INSERTED.Sort,
	INSERTED.CompletedExerciseGroupId,
	INSERTED.CreatedAt
WHERE Id = @Id;