SELECT
	TOP(1) ex.Id,
	ex.Name,
	ex.Instructions,
	ex.Category,
	eq.Name AS 'Equipment'
FROM Exercises ex
JOIN Equipment eq
ON eq.Id = ex.EquipmentId
WHERE ex.Id = @Id;

SELECT
	exMus.Id,
	exMus.ExerciseId,
	exMus.MuscleId,
	exMus.Weight,
	mus.Name AS MuscleName,
	mus.ColorRgb AS ColorRgb
FROM ExercisesMuscles exMus
JOIN Muscles mus
ON exMus.MuscleId = mus.Id
WHERE exMus.ExerciseId = @Id;