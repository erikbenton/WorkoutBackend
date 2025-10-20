INSERT INTO ExerciseSets (MinReps, MaxReps, Weight, Sort, ExerciseGroupId)
OUTPUT INSERTED.Id
VALUES (@MinReps, @MaxReps, @Weight, @Sort, @ExerciseGroupId)