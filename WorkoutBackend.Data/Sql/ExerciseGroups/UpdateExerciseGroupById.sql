UPDATE ExerciseGroups
SET
	Note = @Note,
	RestTimeInSeconds = @RestTimeInSeconds,
	Sort = @Sort,
	ExerciseId = @ExerciseId,
	WorkoutId = @WorkoutId,
	UserId = @UserId
OUTPUT
	INSERTED.Id,
	INSERTED.Note,
	INSERTED.RestTimeInSeconds,
	INSERTED.Sort,
	INSERTED.ExerciseId,
	INSERTED.WorkoutId,
	INSERTED.UserId
WHERE Id = @Id
	AND UserId = @UserId;