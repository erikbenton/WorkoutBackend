CREATE TABLE Programs (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	Description VARCHAR(255)
)

CREATE TABLE Workouts (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	ProgramId INT,
	FOREIGN KEY (ProgramId) REFERENCES Programs(Id)
		ON DELETE CASCADE
)

CREATE TABLE BodyParts (
	Id INT PRIMARY KEY IDENTITY(1,1),
	BodyPart VARCHAR(50) NOT NULL
)

CREATE TABLE Equipment (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Equipment VARCHAR(50) NOT NULL
)

CREATE TABLE Exercises (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	Instructions VARCHAR(500),
	BodyPartId INT NOT NULL,
	EquipmentId INT NOT NULL,
	FOREIGN KEY (BodyPartId) REFERENCES BodyParts(Id),
	FOREIGN KEY (EquipmentId) REFERENCES Equipment(Id)
)

CREATE TABLE ExerciseGroups (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Note VARCHAR(255),
	Sort INT NOT NULL,
	ExerciseId INT NOT NULL,
	WorkoutId INT NOT NULL,
	FOREIGN KEY (ExerciseId) REFERENCES Exercises(Id)
		ON DELETE CASCADE,
	FOREIGN KEY (WorkoutId) REFERENCES Workouts(Id)
		ON DELETE CASCADE
)

CREATE TABLE ExerciseSets (
	Id INT PRIMARY KEY IDENTITY(1,1),
	MinReps INT,
	MaxReps INT,
	Weight FLOAT,
	Sort INT NOT NULL,
	ExerciseGroupId INT NOT NULL,
	FOREIGN KEY (ExerciseGroupId) REFERENCES ExerciseGroups(Id)
		ON DELETE CASCADE
)

CREATE TABLE CompletedWorkouts (
	Id INT PRIMARY KEY IDENTITY(1,1),
	WorkoutId INT, -- NULLable because it might be an "empty workout"
	Name VARCHAR(100), -- Name for when it's an "empty workout" IE: no related Workout
	Note VARCHAR(255),
	DurationInSeconds INT NOT NULL,
	CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (WorkoutId) REFERENCES Workouts(Id) -- Do not DELETE if workout template is deleted
)

CREATE TABLE CompletedExerciseGroups (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Note VARCHAR(255),
	Sort INT NOT NULL,
	ExerciseId INT NOT NULL,
	CompletedWorkoutId INT NOT NULL,
	CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (ExerciseId) REFERENCES Exercises(Id)
		ON DELETE CASCADE,
	FOREIGN KEY (CompletedWorkoutId) REFERENCES CompletedWorkouts(Id)
		ON DELETE CASCADE
)

CREATE TABLE CompletedExerciseSets (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Reps INT NOT NULL,
	Weight FLOAT,
	Sort INT NOT NULL,
	CompletedExerciseGroupId INT NOT NULL,
	CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (CompletedExerciseGroupId) REFERENCES CompletedExerciseGroups(Id)
		ON DELETE CASCADE
)