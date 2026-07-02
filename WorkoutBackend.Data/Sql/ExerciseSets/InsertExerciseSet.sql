INSERT INTO ExerciseSets (MinReps, MaxReps, TargetDurationInSeconds, TargetDistanceinMiles, WeightUnit, DistanceUnit, SetTagId, Sort, ExerciseGroupId, UserId)
OUTPUT
	INSERTED.Id,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.TargetDurationInSeconds,
	INSERTED.TargetDistanceinMiles,
	INSERTED.WeightUnit,
	INSERTED.DistanceUnit,
	INSERTED.SetTagId,
	INSERTED.Sort,
	INSERTED.ExerciseGroupId,
	INSERTED.UserId
VALUES (@MinReps, @MaxReps, @TargetDurationInSeconds, @TargetDistanceinMiles, @WeightUnit, @DistanceUnit, @SetTagId, @Sort, @ExerciseGroupId, @UserId)