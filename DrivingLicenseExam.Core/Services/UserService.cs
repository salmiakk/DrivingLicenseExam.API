﻿using DrivingLicenseExam.Infrastructure.Repository;

namespace DrivingLicenseExam.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
}