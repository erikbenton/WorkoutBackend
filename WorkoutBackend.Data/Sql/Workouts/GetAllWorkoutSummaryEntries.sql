SELECT
	w.Id AS WorkoutId,
	eg.Id AS ExerciseGroupId,
	w.Name AS WorkoutName,
	ex.Name AS ExerciseName
FROM Workouts w
LEFT JOIN ExerciseGroups eg
ON eg.WorkoutId = w.Id
LEFT JOIN Exercises ex
ON eg.ExerciseId = ex.Id
ORDER BY w.Id ASC, eg.Sort ASC