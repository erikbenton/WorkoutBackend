INSERT INTO CompletedExerciseGroups
	(Note, Comment, Sort, ExerciseId, CompletedWorkoutId)
OUTPUT
	INSERTED.Id,
	INSERTED.Note,
	INSERTED.Comment,
	INSERTED.Sort,
	INSERTED.ExerciseId,
	INSERTED.CompletedWorkoutId,
	INSERTED.CreatedAt
VALUES (@Note, @Comment, @Sort, @ExerciseId, @CompletedWorkoutId);