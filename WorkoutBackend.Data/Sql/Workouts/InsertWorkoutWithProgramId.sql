INSERT INTO Workouts (Name, ProgramId)
OUTPUT INSERTED.Id
VALUES (@Name, @ProgramId)