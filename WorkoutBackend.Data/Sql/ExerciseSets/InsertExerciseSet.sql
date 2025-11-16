INSERT INTO ExerciseSets (MinReps, MaxReps, SetType, Sort, ExerciseGroupId)
OUTPUT
	INSERTED.Id,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.SetType,
	INSERTED.Sort,
	INSERTED.ExerciseGroupId
VALUES (@MinReps, @MaxReps, @SetType, @Sort, @ExerciseGroupId)