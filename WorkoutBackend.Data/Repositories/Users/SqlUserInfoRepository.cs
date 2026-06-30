using Dapper;
using Microsoft.Data.SqlClient;
using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.DataAccess;
using WorkoutBackend.Data.Entities;

namespace WorkoutBackend.Data.Repositories.Users;

public class SqlUserInfoRepository(string connectionString) : IUserInfoRepository
{
    private readonly string _connectionString = connectionString;

    public async Task<UserInfo> CreateUserInfoAsync(UserInfo userInfo, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var entityToSave = new UserInfoEntity(userInfo.Username, userInfo.BodyWeight, userInfo.WeightUnit, userInfo.DistanceUnit, userId);
        var savedInfo = await connection.QueryFirstAsync<UserInfo>(UserInfoDataAccess.InsertUserInfo, entityToSave);
        return savedInfo;
    }

    public async Task DeleteUserInfoAsync(string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(UserInfoDataAccess.DeleteUserInfoByUserId, new { userId });
    }

    public async Task<UserInfo> GetUserInfoByIdAsync(string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var userInfo = await connection.QueryFirstAsync<UserInfo>(UserInfoDataAccess.GetUserInfoByUserId, new { userId });
        return userInfo;
    }

    public async Task<UserInfo> UpdateUserInfoAsync(UserInfo userInfo, string userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var entityToUpdate = new UserInfoEntity(userInfo.Username, userInfo.BodyWeight, userInfo.WeightUnit, userInfo.DistanceUnit, userId);
        var savedInfo = await connection.QueryFirstAsync<UserInfo>(UserInfoDataAccess.UpdateUserInfoByUserId, entityToUpdate);
        return savedInfo;
    }
}
