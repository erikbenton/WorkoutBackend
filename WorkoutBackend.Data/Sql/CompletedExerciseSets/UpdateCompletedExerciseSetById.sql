UPDATE CompletedExerciseSets
SET
	Reps = @Reps,
	Weight = @Weight,
	DurationInSeconds = @DurationInSeconds,
	DistanceInMiles = @DistanceInMiles,
	MinReps = @MinReps,
	MaxReps = @MaxReps,
	TargetDurationInSeconds = @TargetDurationInSeconds,
	TargetDistanceinMiles = @TargetDistanceInMiles,
	SetTagId = @SetTagId,
	Sort = @Sort,
	CompletedExerciseGroupId = @CompletedExerciseGroupId,
	CreatedAt = @CreatedAt,
	UserId = @UserId
OUTPUT
	INSERTED.Id,
	INSERTED.Reps,
	INSERTED.Weight,
	INSERTED.DurationInSeconds,
	INSERTED.DistanceInMiles,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.TargetDurationInSeconds,
	INSERTED.TargetDistanceinMiles,
	INSERTED.SetTagId,
	INSERTED.Sort,
	INSERTED.CompletedExerciseGroupId,
	INSERTED.UserId,
	INSERTED.CreatedAt
WHERE Id = @Id
	AND UserId = @UserId;