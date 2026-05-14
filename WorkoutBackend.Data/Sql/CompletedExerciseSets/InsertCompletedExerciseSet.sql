INSERT INTO CompletedExerciseSets
	(Reps, Weight, DurationInSeconds, DistanceInMiles, MinReps, MaxReps, TargetDurationInSeconds, TargetDistanceinMiles, SetTagId, Sort, CompletedExerciseGroupId, UserId)
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
VALUES (@Reps, @Weight, @DurationInSeconds, @DistanceInMiles, @MinReps, @MaxReps, @TargetDurationInSeconds, @TargetDistanceinMiles, @SetTagId, @Sort, @CompletedExerciseGroupId, @UserId);