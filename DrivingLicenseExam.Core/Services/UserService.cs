using DrivingLicenseExam.Core.DTO;
using DrivingLicenseExam.Infrastructure.Entities;
using DrivingLicenseExam.Infrastructure.Repository;

namespace DrivingLicenseExam.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserBasicRequestDto>> GetAllUsersBasicInfoAsync()
    {
        var users = await _userRepository.GetAllAsync();
        
        return users.Select(x => new UserBasicRequestDto(
            x.FirstName,
            x.Surname,
            x.Email
        ));
    }

    public async Task AddNewUserAsync(UserBasicRequestDto dto)
    {
        await _userRepository.AddAsync(new User
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                Surname = dto.Surname
            }
        );
    }

    public async Task UpdateExistingUserAsync(UserUpdateRequestDto dto)
    {
        await _userRepository.UpdateAsync(new User
        {
            Email = dto.Email,
            FirstName = dto.FirstName,
            Surname = dto.Surname,
            Id = dto.ExistingUserId
        });
    }

    public async Task DeleteExistingUserByIdAsync(int id)
    {
        await _userRepository.DeleteById(id);
    }
}