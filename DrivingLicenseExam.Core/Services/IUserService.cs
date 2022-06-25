using DrivingLicenseExam.Core.DTO;

namespace DrivingLicenseExam.Core.Services;

public interface IUserService
{
    Task<IEnumerable<UserBasicRequestDto>> GetAllUsersBasicInfoAsync();
    Task AddNewUserAsync(UserBasicRequestDto dto);
    Task UpdateExistingUserAsync(UserUpdateRequestDto dto);
    Task DeleteExistingUserByIdAsync(int id);
}