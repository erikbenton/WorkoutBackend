INSERT INTO CompletedWorkouts (WorkoutId, Name, Note, DurationInSeconds)
VALUES (1, NULL, 'Testing Completed Workouts', 3605);

INSERT INTO CompletedExerciseGroups (Note, Sort, ExerciseId, CompletedWorkoutId)
VALUES  ('First Group', 0,
			(SELECT Id FROM Exercises WHERE Name = 'Barbell Bench Press'),
			(SELECT Id FROM CompletedWorkouts WHERE Note = 'Testing Completed Workouts')),
		('Second Group', 1,
			(SELECT Id FROM Exercises WHERE Name = 'Incline Dumbbell Bench Press'),
			(SELECT Id FROM CompletedWorkouts WHERE Note = 'Testing Completed Workouts')),
		('Third Group', 2,
			(SELECT Id FROM Exercises WHERE Name = 'Dumbbell Shoulder Press'),
			(SELECT Id FROM CompletedWorkouts WHERE Note = 'Testing Completed Workouts'));

INSERT INTO CompletedExerciseSets (Reps, Weight, Sort, CompletedExerciseGroupId)
VALUES  -- First Group Sets
		(10, 45, 0,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'First Group')),
		(8, 90, 1,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'First Group')),
		(5, 135, 2,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'First Group')),
		(5, 135, 3,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'First Group')),
		(5, 135, 4,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'First Group')),
		-- Second Group Sets
		(8, 15, 0,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'Second Group')),
		(8, 25, 1,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'Second Group')),
		(5, 45, 2,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'Second Group')),
		(5, 45, 3,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'Second Group')),
		-- Third Group Sets
		(8, 15, 0,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'Third Group')),
		(8, 25, 1,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'Third Group')),
		(5, 45, 2,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'Third Group')),
		(5, 45, 3,
			(SELECT Id FROM CompletedExerciseGroups WHERE Note = 'Third Group'));