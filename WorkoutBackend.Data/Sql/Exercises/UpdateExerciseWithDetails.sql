UPDATE Exercises SET
	Name = @Name,
	Instructions = @Instructions,
	BodyPartId = (SELECT Id FROM BodyParts WHERE BodyPart = @BodyPart),
	EquipmentId = (SELECT Id FROM Equipment WHERE Equipment = @Equipment)
WHERE Id = @Id