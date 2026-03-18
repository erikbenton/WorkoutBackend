SELECT Id, Name, Description, ProgramId, UserId
FROM Workouts
WHERE UserId = @UserId;