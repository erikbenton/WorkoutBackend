SELECT
	ex.Id,
	ex.Name,
	ex.Category,
	ex.Instructions,
	eq.Name AS Equipment
FROM Exercises ex
JOIN Equipment eq
ON eq.Id = ex.EquipmentId;

SELECT
	exMus.Id,
	exMus.ExerciseId,
	exMus.MuscleId,
	exMus.Weight,
	mus.Name AS MuscleName
FROM ExercisesMuscles exMus
JOIN Muscles mus
ON mus.Id = exMus.MuscleId;