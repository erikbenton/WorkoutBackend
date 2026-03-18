INSERT INTO ExerciseSets (MinReps, MaxReps, SetTagId, Sort, ExerciseGroupId, UserId)
OUTPUT
	INSERTED.Id,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.SetTagId,
	INSERTED.Sort,
	INSERTED.ExerciseGroupId,
	INSERTED.UserId
VALUES (@MinReps, @MaxReps, @SetTagId, @Sort, @ExerciseGroupId, @UserId)