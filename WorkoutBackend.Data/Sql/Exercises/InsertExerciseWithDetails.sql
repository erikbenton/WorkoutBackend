INSERT INTO Exercises (Name, Instructions, Category, EquipmentId)
OUTPUT INSERTED.Id
VALUES (@Name,
		@Instructions,
		@Category,
		(SELECT Id FROM Equipment eq WHERE eq.Name = @Equipment));