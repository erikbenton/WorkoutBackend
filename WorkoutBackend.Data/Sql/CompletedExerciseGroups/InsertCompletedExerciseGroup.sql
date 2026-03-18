INSERT INTO CompletedExerciseGroups
	(Note, Comment, RestTimeInSeconds, Sort, ExerciseId, CompletedWorkoutId, UserId)
OUTPUT
	INSERTED.Id,
	INSERTED.Note,
	INSERTED.Comment,
	INSERTED.RestTimeInSeconds,
	INSERTED.Sort,
	INSERTED.ExerciseId,
	INSERTED.CompletedWorkoutId,
	INSERTED.UserId,
	INSERTED.CreatedAt
VALUES (@Note, @Comment, @RestTimeInSeconds, @Sort, @ExerciseId, @CompletedWorkoutId, @UserId);