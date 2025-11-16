UPDATE ExerciseSets
SET
	MinReps = @MinReps,
	MaxReps = @MaxReps,
	SetType = @SetType,
	Sort = @Sort,
	ExerciseGroupId = @ExerciseGroupId
OUTPUT
	INSERTED.Id,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.SetType,
	INSERTED.Sort,
	INSERTED.ExerciseGroupId
WHERE Id = @Id