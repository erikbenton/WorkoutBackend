INSERT INTO ExerciseSets (Reps, Weight, Sort, ExerciseGroupId)
OUTPUT INSERTED.Id
VALUES (@Reps, @Weight, @Sort, @ExerciseGroupId)