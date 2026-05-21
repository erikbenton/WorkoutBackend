DELETE FROM ProgramWorkouts
WHERE ProgramId = @ProgramId
	AND UserId = @UserId;