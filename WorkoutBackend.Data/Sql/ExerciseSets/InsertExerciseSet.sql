INSERT INTO ExerciseSets (MinReps, MaxReps, SetTagId, Sort, ExerciseGroupId)
OUTPUT
	INSERTED.Id,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.SetTagId,
	INSERTED.Sort,
	INSERTED.ExerciseGroupId
VALUES (@MinReps, @MaxReps, @SetTagId, @Sort, @ExerciseGroupId)