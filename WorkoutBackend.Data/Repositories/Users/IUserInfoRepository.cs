using WorkoutBackend.Core.Models;

namespace WorkoutBackend.Data.Repositories.Users;

public interface IUserInfoRepository
{
    public Task<UserInfo> GetUserInfoByIdAsync(string userId);

    public Task<UserInfo> CreateUserInfoAsync(UserInfo userInfo, string userId);

    public Task<UserInfo> UpdateUserInfoAsync(UserInfo userInfo, string userId);

    public Task DeleteUserInfoAsync(string userId);
}
