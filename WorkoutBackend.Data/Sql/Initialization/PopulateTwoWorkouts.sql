--Workouts
INSERT INTO Workouts (Name, ProgramId)
VALUES ('Push A', NULL),
		('Pull A', NULL)

INSERT INTO ExerciseGroups (Note, Sort, ExerciseId, WorkoutId)
VALUES  --This is for first workout
		('Note for first set of first workout', 0,
			(SELECT Id FROM Exercises WHERE Name = 'Barbell Bench Press'),
			(SELECT Id FROM Workouts WHERE Name = 'Push A')),
		('Note for second set of first workout', 1,
			(SELECT Id FROM Exercises WHERE Name = 'Incline Dumbbell Bench Press'),
			(SELECT Id FROM Workouts WHERE Name = 'Push A')),
		('Note for third set of first workout', 2,
			(SELECT Id FROM Exercises WHERE Name = 'Dumbbell Shoulder Press'),
			(SELECT Id FROM Workouts WHERE Name = 'Push A')),
		--This is for second Workout
		('Note for first set of second workout', 0,
			(SELECT Id FROM Exercises WHERE Name = 'Pull-Up'),
			(SELECT Id FROM Workouts WHERE Name = 'Pull A')),
		('Note for second set of second workout', 1,
			(SELECT Id FROM Exercises WHERE Name = 'Horizontal Machine Rows'),
			(SELECT Id FROM Workouts WHERE Name = 'Pull A')),
		('Note for third set of second workout', 2,
			(SELECT Id FROM Exercises WHERE Name = 'Alternating Dumbbell Curls'),
			(SELECT Id FROM Workouts WHERE Name = 'Pull A'))

INSERT INTO ExerciseSets (MinReps, MaxReps, Weight, Sort, ExerciseGroupId)
VALUES --first workout, first ExerciseGroup
		(10, NULL, 45, 0,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for first set of first workout' )),
		(8, NULL, 90, 1,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for first set of first workout' )),
		(4, 6, 135, 2,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for first set of first workout' )),
		--first workout, second ExerciseGroup
		(10, 12, 15, 0,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for second set of first workout' )),
		(8, 10, 25, 1,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for second set of first workout' )),
		(4, 6, 45, 2,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for second set of first workout' )),
		-- first workout, third ExerciseGroup
		(10, 12, 15, 0,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for third set of first workout' )),
		(6, 8, 25, 1,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for third set of first workout' )),
		(4, 6, 45, 2,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for third set of first workout' )),

		-- second workout, first ExerciseGroup
		(6, 10, 0, 0,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for first set of second workout' )),
		(6, 10, 0, 1,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for first set of second workout' )),
		(6, 10, 0, 2,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for first set of second workout' )),
		--first workout, second ExerciseGroup
		(8, 10, 20, 0,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for second set of second workout' )),
		(6, 8, 30, 1,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for second set of second workout' )),
		(4, 6, 70, 2,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for second set of second workout' )),
		-- first workout, third ExerciseGroup
		(6, 8, 25, 0,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for third set of second workout' )),
		(6, 8, 25, 1,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for third set of second workout' )),
		(6, 8, 25, 2,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for third set of second workout' ))