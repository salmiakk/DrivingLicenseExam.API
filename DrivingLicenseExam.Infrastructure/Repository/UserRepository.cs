using DrivingLicenseExam.Infrastructure.Context;
using DrivingLicenseExam.Infrastructure.Entities;

namespace DrivingLicenseExam.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    public readonly MainContext _mainContext;

    public UserRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}