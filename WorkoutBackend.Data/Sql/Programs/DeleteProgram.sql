DELETE FROM Programs
WHERE Id = @Id
	AND UserId = @UserId;