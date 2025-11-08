SELECT
	ex.Id,
	ex.Name,
	ex.Instructions,
	bp.BodyPart,
	eq.Equipment
FROM Exercises ex
JOIN BodyParts bp
ON bp.Id = ex.BodyPartId
JOIN Equipment eq
ON eq.Id = ex.EquipmentId
ORDER BY ex.Name