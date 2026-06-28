using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Services;

public interface IUserInfoService
{
    public Task<UserInfo> GetUserInfo(string userId);
    public Task<UserInfo> CreateUserInfo(UserInfo userInfo, string userId);
    public Task<UserInfo> UpdateUserInfo(UserInfo userInfo, string userId);
    public Task DeleteUserInfo(string userId);
}
