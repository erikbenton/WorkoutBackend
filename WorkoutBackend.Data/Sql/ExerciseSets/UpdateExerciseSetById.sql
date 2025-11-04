UPDATE ExerciseSets
SET
	MinReps = @MinReps,
	MaxReps = @MaxReps,
	Weight = @Weight,
	Sort = @Sort,
	ExerciseGroupId = @ExerciseGroupId
OUTPUT
	INSERTED.Id,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.Weight,
	INSERTED.Sort,
	INSERTED.ExerciseGroupId
WHERE Id = @Id