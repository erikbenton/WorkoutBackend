SELECT
	cw.Id,
	cw.Name,
	cw.Description,
	cw.Note,
	cw.DurationInSeconds,
	cw.CreatedAt,
	cw.UserId
FROM CompletedWorkouts cw
WHERE cw.Id = @Id
	AND cw.UserId = @UserId;