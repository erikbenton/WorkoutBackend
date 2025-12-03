INSERT INTO CompletedExerciseGroups
	(Note, Comment, RestTimeInSeconds, Sort, ExerciseId, CompletedWorkoutId)
OUTPUT
	INSERTED.Id,
	INSERTED.Note,
	INSERTED.Comment,
	INSERTED.RestTimeInSeconds,
	INSERTED.Sort,
	INSERTED.ExerciseId,
	INSERTED.CompletedWorkoutId,
	INSERTED.CreatedAt
VALUES (@Note, @Comment, @RestTimeInSeconds, @Sort, @ExerciseId, @CompletedWorkoutId);