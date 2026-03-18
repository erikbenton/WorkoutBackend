SELECT Id, MinReps, MaxReps, SetTagId, Sort, ExerciseGroupId, UserId
FROM ExerciseSets
WHERE Id = @Id
	AND UserId = @UserId;