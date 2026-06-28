UPDATE UserInfo SET
	Username = @Username,
	BodyWeight = @BodyWeight,
	WeightUnit = @WeightUnit,
	DistanceUnit = @DistanceUnit
OUTPUT
	INSERTED.Username,
	INSERTED.BodyWeight,
	INSERTED.WeightUnit,
	INSERTED.DistanceUnit
WHERE
	UserId = @UserId