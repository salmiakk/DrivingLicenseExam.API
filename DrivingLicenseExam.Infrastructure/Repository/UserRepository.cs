using DrivingLicenseExam.Infrastructure.Context;
using DrivingLicenseExam.Infrastructure.Entities;
using DrivingLicenseExam.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DrivingLicenseExam.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly MainContext _mainContext;
    private readonly ILogger<User> _logger;

    public UserRepository(MainContext mainContext, ILogger<User> logger)
    {
        _mainContext = mainContext;
        _logger = logger;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _mainContext.User.ToListAsync();
        return users;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _mainContext.User.SingleOrDefaultAsync(x => x.Id == id);
        if (user != null)
        {
            return user;
        }
        _logger.LogError("Cannot find user with provided id: {UserId}", id);
        throw new EntityNotFoundException();
    }

    public async Task AddAsync(User entity)
    {
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        var usersToUpdate = await _mainContext.User.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (usersToUpdate == null)
        {
            _logger.LogError("Cannot find user with provided id: {UserId}", entity.Id);
            throw new EntityNotFoundException();
        }

        usersToUpdate.Email = entity.Email;
        usersToUpdate.FirstName = entity.FirstName;
        usersToUpdate.Surname = entity.Surname;
        usersToUpdate.DateOfUpdate = DateTime.UtcNow;

        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var usersToDelete = await _mainContext.User.SingleOrDefaultAsync(x => x.Id == id);
        if (usersToDelete != null)
        {
            _mainContext.User.Remove(usersToDelete);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            _logger.LogError("Cannot find user with provided id: {UserId}", id);
            throw new EntityNotFoundException();
        }
    }
}