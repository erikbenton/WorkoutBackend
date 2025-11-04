INSERT INTO ExerciseGroups (Note, RestTimeInSeconds, Sort, ExerciseId, WorkoutId)
OUTPUT INSERTED.Id
VALUES (@Note, @RestTimeInSeconds, @Sort, @ExerciseId, @WorkoutId)