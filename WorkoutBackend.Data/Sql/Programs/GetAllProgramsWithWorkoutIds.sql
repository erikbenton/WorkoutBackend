SELECT Id, Name, ColorRgb, Description, UserId
FROM Programs
WHERE UserId = @UserId;

SELECT Id, ProgramId, WorkoutId, Sort, UserId
FROM ProgramWorkouts
WHERE UserId = @UserId;