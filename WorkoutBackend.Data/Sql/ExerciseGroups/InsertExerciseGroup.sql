INSERT INTO ExerciseGroups (Note, Sort, ExerciseId, WorkoutId)
OUTPUT INSERTED.Id
VALUES (@Note, @Sort, @ExerciseId, @WorkoutId)