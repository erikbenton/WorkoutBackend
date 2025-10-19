SELECT TOP(1) ex.Id, ex.Name, ex.Instructions, bp.BodyPart, eq.Equipment
FROM Exercises ex
JOIN BodyParts bp
ON bp.Id = ex.BodyPartId
JOIN Equipment eq
ON eq.Id = ex.EquipmentId
WHERE ex.Id = @Id