SELECT Id, MinReps, MaxReps, TargetDurationInSeconds, TargetDistanceinMiles, SetTagId, Sort, ExerciseGroupId, UserId
FROM ExerciseSets
WHERE Id = @Id
	AND UserId = @UserId;