SELECT Id, ProgramId, WorkoutId, Sort, UserId
FROM ProgramWorkouts
WHERE ProgramId = @ProgramId
	AND UserId = @UserId;