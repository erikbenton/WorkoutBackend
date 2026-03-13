--Workouts
INSERT INTO Workouts (Name, Description, ProgramId)
VALUES ('Push A', 'Pushing day for the Push, Pull Leg workout', NULL),
		('Pull A', 'Pulling day for the Push, Pull Leg workout', NULL)

INSERT INTO ExerciseGroups (Note, RestTimeInSeconds, Sort, ExerciseId, WorkoutId)
VALUES  --This is for first workout
		('Note for first set of first workout', 180, 0,
			(SELECT Id FROM Exercises WHERE Name = 'Barbell Bench Press'),
			(SELECT Id FROM Workouts WHERE Name = 'Push A')),
		('Note for second set of first workout', 180, 1,
			(SELECT Id FROM Exercises WHERE Name = 'Incline Dumbbell Bench Press'),
			(SELECT Id FROM Workouts WHERE Name = 'Push A')),
		('Note for third set of first workout', 180, 2,
			(SELECT Id FROM Exercises WHERE Name = 'Dumbbell Shoulder Press'),
			(SELECT Id FROM Workouts WHERE Name = 'Push A')),
		--This is for second Workout
		('Note for first set of second workout', 180, 0,
			(SELECT Id FROM Exercises WHERE Name = 'Pull-Up'),
			(SELECT Id FROM Workouts WHERE Name = 'Pull A')),
		('Note for second set of second workout', 180, 1,
			(SELECT Id FROM Exercises WHERE Name = 'Horizontal Machine Rows'),
			(SELECT Id FROM Workouts WHERE Name = 'Pull A')),
		('Note for third set of second workout', 180, 2,
			(SELECT Id FROM Exercises WHERE Name = 'Alternating Dumbbell Curls'),
			(SELECT Id FROM Workouts WHERE Name = 'Pull A'))

INSERT INTO ExerciseSets (MinReps, MaxReps, SetTagId, Sort, ExerciseGroupId)
VALUES --first workout, first ExerciseGroup
		(10, NULL, 1, 0,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for first set of first workout' )),
		(8, NULL, 1, 1,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for first set of first workout' )),
		(4, 6, 2, 2,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for first set of first workout' )),
		--first workout, second ExerciseGroup
		(10, 12, 1, 0,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for second set of first workout' )),
		(8, 10, 1, 1,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for second set of first workout' )),
		(4, 6, 5, 2,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for second set of first workout' )),
		-- first workout, third ExerciseGroup
		(10, 12, 1, 0,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for third set of first workout' )),
		(6, 8, 1, 1,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for third set of first workout' )),
		(4, 6, 5, 2,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for third set of first workout' )),

		-- second workout, first ExerciseGroup
		(6, 10, 2, 0,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for first set of second workout' )),
		(6, 10, 2, 1,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for first set of second workout' )),
		(6, 10, 2, 2,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for first set of second workout' )),
		--first workout, second ExerciseGroup
		(8, 10, 1, 0,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for second set of second workout' )),
		(6, 8, 1, 1,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for second set of second workout' )),
		(4, 6, 2, 2,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for second set of second workout' )),
		-- first workout, third ExerciseGroup
		(6, 8, 2, 0,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for third set of second workout' )),
		(6, 8, 2, 1,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for third set of second workout' )),
		(6, 8, 2, 2,
			(SELECT Id FROM ExerciseGroups WHERE Note = 'Note for third set of second workout' ))