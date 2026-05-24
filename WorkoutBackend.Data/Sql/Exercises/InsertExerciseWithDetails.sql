INSERT INTO Exercises (Name, Instructions, Category, UserId, EquipmentId)
OUTPUT INSERTED.Id
VALUES (@Name,
		@Instructions,
		@Category,
		@UserId,
		(SELECT Id FROM Equipment eq WHERE eq.Name = @Equipment));