UPDATE ExerciseSets
SET
	MinReps = @MinReps,
	MaxReps = @MaxReps,
	SetTagId = @SetTagId,
	Sort = @Sort,
	ExerciseGroupId = @ExerciseGroupId,
	UserId = @UserId
OUTPUT
	INSERTED.Id,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.SetTagId,
	INSERTED.Sort,
	INSERTED.ExerciseGroupId,
	INSERTED.UserId
WHERE Id = @Id
	AND UserId = @UserId;