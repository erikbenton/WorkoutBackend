SELECT Id, Note, RestTimeInSeconds, WorkoutId, ExerciseId, Sort
FROM ExerciseGroups
WHERE WorkoutId = (SELECT Id FROM Workouts WHERE Name = @WorkoutName)
ORDER BY Sort ASC