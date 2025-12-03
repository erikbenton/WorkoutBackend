SELECT
	cw.Id,
	cw.WorkoutId,
	cw.Name,
	cw.Description,
	cw.Note,
	cw.DurationInSeconds,
	cw.CreatedAt
FROM CompletedWorkouts cw
WHERE cw.Id = @Id;