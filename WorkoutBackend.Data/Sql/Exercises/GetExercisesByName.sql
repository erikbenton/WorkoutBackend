SELECT ex.Id, ex.Name, ex.Instructions, bp.BodyPart, eq.Equipment
FROM Exercises ex
JOIN BodyParts bp
ON ex.BodyPartId = bp.Id
JOIN Equipment eq
ON ex.EquipmentId = eq.Id
WHERE ex.Name LIKE '%' + @Name + '%'