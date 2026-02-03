UPDATE Exercises SET
	Name = @Name,
	Instructions = @Instructions,
	Category = @Category,
	EquipmentId = (SELECT eq.Id FROM Equipment eq WHERE eq.Name = @Equipment)
WHERE Id = @Id