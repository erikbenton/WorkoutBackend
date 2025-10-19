INSERT INTO Exercises (Name, Instructions, BodyPartId, EquipmentId)
OUTPUT INSERTED.Id
VALUES (@Name,
		@Instructions,
		(SELECT Id FROM BodyParts WHERE BodyPart = @BodyPart),
		(SELECT Id FROM Equipment WHERE Equipment = @Equipment));