UPDATE ExerciseSets
SET
	MinReps = @MinReps,
	MaxReps = @MaxReps,
	SetTagId = @SetTagId,
	Sort = @Sort,
	ExerciseGroupId = @ExerciseGroupId
OUTPUT
	INSERTED.Id,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.SetTagId,
	INSERTED.Sort,
	INSERTED.ExerciseGroupId
WHERE Id = @Id