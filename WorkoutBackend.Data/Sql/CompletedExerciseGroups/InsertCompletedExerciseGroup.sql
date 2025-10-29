INSERT INTO CompletedExerciseGroups
	(Note, Sort, ExerciseId, CompletedWorkoutId)
OUTPUT
	INSERTED.Id,
	INSERTED.Note,
	INSERTED.Sort,
	INSERTED.ExerciseId,
	INSERTED.CompletedWorkoutId,
	INSERTED.CreatedAt
VALUES (@Note, @Sort, @ExerciseId, @CompletedWorkoutId);