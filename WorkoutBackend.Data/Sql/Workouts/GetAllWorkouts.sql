SELECT Id, Name, Description, UserId
FROM Workouts
WHERE UserId = @UserId;