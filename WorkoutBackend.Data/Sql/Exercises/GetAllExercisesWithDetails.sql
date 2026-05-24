SELECT
	ex.Id,
	ex.Name,
	ex.Instructions,
	ex.Category,
	eq.Name AS Equipment,
	ex.UserId
FROM Exercises ex
JOIN Equipment eq
ON eq.Id = ex.EquipmentId;

SELECT
	exMus.Id,
	exMus.ExerciseId,
	exMus.MuscleId,
	exMus.Weight,
	mus.Name AS MuscleName,
	mus.ColorRgb as ColorRgb
FROM ExercisesMuscles exMus
JOIN Muscles mus
ON mus.Id = exMus.MuscleId;