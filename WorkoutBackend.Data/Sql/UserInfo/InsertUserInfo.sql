INSERT INTO UserInfo
	(UserName, BodyWeight, WeightUnit, DistanceUnit, UserId)
OUTPUT
	INSERTED.Username,
	INSERTED.BodyWeight,
	INSERTED.WeightUnit,
	INSERTED.DistanceUnit
VALUES (@Username, @BodyWeight, @WeightUnit, @DistanceUnit, @UserId)