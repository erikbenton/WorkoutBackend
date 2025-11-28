UPDATE CompletedExerciseSets
SET
	Reps = @Reps,
	Weight = @Weight,
	MinReps = @MinReps,
	MaxReps = @MaxReps,
	SetType = @SetType,
	Sort = @Sort,
	CompletedExerciseGroupId = @CompletedExerciseGroupId,
	CreatedAt = @CreatedAt
OUTPUT
	INSERTED.Id,
	INSERTED.Reps,
	INSERTED.Weight,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.SetType,
	INSERTED.Sort,
	INSERTED.CompletedExerciseGroupId,
	INSERTED.CreatedAt
WHERE Id = @Id;