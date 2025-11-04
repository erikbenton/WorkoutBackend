INSERT INTO ExerciseGroups (Note, RestTimeInSeconds, Sort, ExerciseId, WorkoutId)
OUTPUT
	INSERTED.Id,
	INSERTED.Note,
	INSERTED.RestTimeInSeconds,
	INSERTED.Sort,
	INSERTED.ExerciseId,
	INSERTED.WorkoutId
VALUES (@Note, @RestTimeInSeconds, @Sort, @ExerciseId, @WorkoutId)