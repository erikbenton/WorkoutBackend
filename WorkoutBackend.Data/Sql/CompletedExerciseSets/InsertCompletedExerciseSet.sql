INSERT INTO CompletedExerciseSets
	(Reps, Weight, MinReps, MaxReps, SetTagId, Sort, CompletedExerciseGroupId)
OUTPUT
	INSERTED.Id,
	INSERTED.Reps,
	INSERTED.Weight,
	INSERTED.MinReps,
	INSERTED.MaxReps,
	INSERTED.SetTagId,
	INSERTED.Sort,
	INSERTED.CompletedExerciseGroupId,
	INSERTED.CreatedAt
VALUES (@Reps, @Weight,@MinReps, @MaxReps, @SetTagId, @Sort, @CompletedExerciseGroupId);