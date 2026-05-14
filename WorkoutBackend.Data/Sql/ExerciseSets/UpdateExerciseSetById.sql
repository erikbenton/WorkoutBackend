UPDATE ExerciseSets
SET
	MinReps = @MinReps,
	MaxReps = @MaxReps,
	TargetDurationInSeconds = @TargetDurationInSeconds,
	TargetDistanceinMiles = @TargetDistanceInMiles,
	SetTagId = @SetTagId,
	Sort = @Sort,
	ExerciseGroupId = @ExerciseGroupId,
	UserId = @UserId
OUTPUT
	INSERTED.Id,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.TargetDurationInSeconds,
	INSERTED.TargetDistanceinMiles,
	INSERTED.SetTagId,
	INSERTED.Sort,
	INSERTED.ExerciseGroupId,
	INSERTED.UserId
WHERE Id = @Id
	AND UserId = @UserId;