UPDATE ExerciseGroups
SET
	Note = @Note,
	RestTimeInSeconds = @RestTimeInSeconds,
	Sort = @Sort,
	ExerciseId = @ExerciseId,
	WorkoutId = @WorkoutId
OUTPUT
	INSERTED.Id,
	INSERTED.Note,
	INSERTED.RestTimeInSeconds,
	INSERTED.Sort,
	INSERTED.ExerciseId,
	INSERTED.WorkoutId 
WHERE Id = @Id