SELECT
	cw.Id,
	cw.WorkoutId,
	cw.Name,
	cw.Note,
	cw.DurationInSeconds,
	cw.CreatedAt
FROM CompletedWorkouts cw
WHERE cw.Id = @Id;