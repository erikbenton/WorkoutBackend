INSERT INTO Workouts (Name, Description, UserId)
OUTPUT
	INSERTED.Id,
	INSERTED.Name,
	INSERTED.Description,
	INSERTED.UserId
VALUES (@Name, @Description, @UserId);