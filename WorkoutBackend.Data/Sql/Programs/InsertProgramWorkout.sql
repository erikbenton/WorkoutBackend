INSERT INTO ProgramWorkouts (ProgramId, WorkoutId, Sort, UserId)
OUTPUT
	INSERTED.ID,
	INSERTED.ProgramId,
	INSERTED.WorkoutId,
	INSERTED.Sort,
	INSERTED.UserId
VALUES (@ProgramId, @WorkoutId, @Sort, @UserId);