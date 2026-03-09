INSERT INTO ExercisesMuscles (ExerciseId, MuscleId, Weight)
VALUES  (@ExerciseId,
		(SELECT Id FROM Muscles mus WHERE mus.Name = @MuscleName),
		 @Weight);