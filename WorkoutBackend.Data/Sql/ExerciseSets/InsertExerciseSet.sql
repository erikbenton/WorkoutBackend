INSERT INTO ExerciseSets (MinReps, MaxReps, Weight, Sort, ExerciseGroupId)
OUTPUT
	INSERTED.Id,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.Weight,
	INSERTED.Sort,
	INSERTED.ExerciseGroupId
VALUES (@MinReps, @MaxReps, @Weight, @Sort, @ExerciseGroupId)