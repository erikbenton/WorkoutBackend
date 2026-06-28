using WorkoutBackend.Core.Models;
using WorkoutBackend.Data.Repositories.Users;

namespace WorkoutBackend.Data.Services;

public class UserInfoService(IUserInfoRepository userInfoRepository) : IUserInfoService
{
    private readonly IUserInfoRepository _userInfoRepository = userInfoRepository;

    public async Task<UserInfo> CreateUserInfo(UserInfo userInfo, string userId)
    {
        return await _userInfoRepository.CreateUserInfoAsync(userInfo, userId);
    }

    public async Task DeleteUserInfo(string userId)
    {
        await _userInfoRepository.DeleteUserInfoAsync(userId);
    }

    public async Task<UserInfo> GetUserInfo(string userId)
    {
        return await _userInfoRepository.GetUserInfoByIdAsync(userId);
    }

    public async Task<UserInfo> UpdateUserInfo(UserInfo userInfo, string userId)
    {
        return await _userInfoRepository.UpdateUserInfoAsync(userInfo, userId);
    }
}
