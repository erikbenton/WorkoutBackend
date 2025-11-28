INSERT INTO CompletedExerciseSets
	(Reps, Weight, MinReps, MaxReps, SetType, Sort, CompletedExerciseGroupId)
OUTPUT
	INSERTED.Id,
	INSERTED.Reps,
	INSERTED.Weight,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.SetType,
	INSERTED.Sort,
	INSERTED.CompletedExerciseGroupId,
	INSERTED.CreatedAt
VALUES (@Reps, @Weight,@MinReps, @MaxReps, @SetType, @Sort, @CompletedExerciseGroupId);