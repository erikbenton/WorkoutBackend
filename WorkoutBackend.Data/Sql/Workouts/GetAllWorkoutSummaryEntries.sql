SELECT
	w.Id AS WorkoutId,
	eg.Id AS ExerciseGroupId,
	w.Name AS WorkoutName,
	ex.Name AS ExerciseName
FROM Workouts w
JOIN ExerciseGroups eg
ON eg.WorkoutId = w.Id
JOIN Exercises ex
ON eg.ExerciseId = ex.Id
ORDER BY w.Id ASC, eg.Sort ASC