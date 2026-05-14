SELECT Id, MinReps, MaxReps, TargetDurationInSeconds, TargetDistanceinMiles, SetTagId, Sort, ExerciseGroupId, UserId
FROM ExerciseSets
WHERE ExerciseGroupId = @ExerciseGroupId
	AND UserId = @UserId
ORDER BY Sort ASC