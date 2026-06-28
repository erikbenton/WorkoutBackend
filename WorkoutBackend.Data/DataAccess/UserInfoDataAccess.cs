namespace WorkoutBackend.Data.DataAccess;

public static class UserInfoDataAccess
{
    private static readonly string sqlFolder = "Sql/UserInfo";

    public static string GetUserInfoByUserId => DataAccessHelper.GetSqlString(sqlFolder, "GetUserInfoByUserId.sql");
    public static string InsertUserInfo => DataAccessHelper.GetSqlString(sqlFolder, "InsertUserInfo.sql");
    public static string UpdateUserInfoByUserId => DataAccessHelper.GetSqlString(sqlFolder, "UpdateUserInfoByUserId.sql");
    public static string DeleteUserInfoByUserId => DataAccessHelper.GetSqlString(sqlFolder, "DeleteUserInfoByUserId.sql");
}