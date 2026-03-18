INSERT INTO ExerciseGroups (Note, RestTimeInSeconds, Sort, ExerciseId, WorkoutId, UserId)
OUTPUT
	INSERTED.Id,
	INSERTED.Note,
	INSERTED.RestTimeInSeconds,
	INSERTED.Sort,
	INSERTED.ExerciseId,
	INSERTED.WorkoutId,
	INSERTED.UserId
VALUES (@Note, @RestTimeInSeconds, @Sort, @ExerciseId, @WorkoutId, @UserId)