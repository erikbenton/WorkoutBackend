SELECT Id, Name, Description, ColorRgb, Tag, UserId
FROM Workouts
WHERE UserId = @UserId;