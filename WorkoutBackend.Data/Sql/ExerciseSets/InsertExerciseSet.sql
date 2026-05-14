INSERT INTO ExerciseSets (MinReps, MaxReps, TargetDurationInSeconds, TargetDistanceinMiles, SetTagId, Sort, ExerciseGroupId, UserId)
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
VALUES (@MinReps, @MaxReps, @TargetDurationInSeconds, @TargetDistanceinMiles, @SetTagId, @Sort, @ExerciseGroupId, @UserId)