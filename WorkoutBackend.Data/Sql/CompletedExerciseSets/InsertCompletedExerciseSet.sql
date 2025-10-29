INSERT INTO CompletedExerciseSets
	(Reps, Weight, Sort, CompletedExerciseGroupId)
OUTPUT
	INSERTED.Id,
	INSERTED.Reps,
	INSERTED.Weight,
	INSERTED.Sort,
	INSERTED.CompletedExerciseGroupId,
	INSERTED.CreatedAt
VALUES (@Reps, @Weight, @Sort, @CompletedExerciseGroupId);