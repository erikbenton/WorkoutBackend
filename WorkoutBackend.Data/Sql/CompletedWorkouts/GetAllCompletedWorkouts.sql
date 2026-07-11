SELECT
	cw.Id,
	cw.Name,
	cw.Description,
	cw.ColorRgb,
	cw.Tag,
	cw.Note,
	cw.DurationInSeconds,
	cw.UserId,
	cw.CreatedAt
FROM CompletedWorkouts cw
WHERE cw.UserId = @UserId
ORDER BY cw.CreatedAt DESC;