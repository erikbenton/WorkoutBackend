SELECT
	Username,
	BodyWeight,
	WeightUnit,
	DistanceUnit
From UserInfo
WHERE UserId = @UserId