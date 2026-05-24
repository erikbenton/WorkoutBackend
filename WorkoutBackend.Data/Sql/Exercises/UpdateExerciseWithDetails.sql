UPDATE Exercises SET
	Name = @Name,
	Instructions = @Instructions,
	Category = @Category,
	UserId = @UserId,
	EquipmentId = (SELECT eq.Id FROM Equipment eq WHERE eq.Name = @Equipment)
WHERE Id = @Id
	AND UserId = @UserId