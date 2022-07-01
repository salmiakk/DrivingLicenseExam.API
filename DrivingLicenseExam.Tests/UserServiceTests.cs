using DrivingLicenseExam.Core.Services;
using DrivingLicenseExam.Infrastructure.Entities;
using DrivingLicenseExam.Infrastructure.Repository;
using FluentAssertions;
using Moq;

namespace DrivingLicenseExam.Tests;

public class UserServiceTests
{
    [Fact]
    public async Task GetAllUsersBasicInfoAsync_ShouldReturnEmpty_WhenUsersCollectionIsEmpty()
    {
        var sut = new UserService(Mock.Of<IUserRepository>());
        
        var result = await sut.GetAllUsersBasicInfoAsync();
        
        result.Should().BeEmpty();

    }
    
    [Fact]
    public async Task GetAllUsersBasicInfoAsync_ShouldReturnTwoElements_WhenUsersCollectionHasTwoElements()
    {
        var users = new List<User>
        {
            new()
            {
                Email = "grzegorz.bulka@wp.pl",
                FirstName = "Grzegorz",
                Surname = "Bulka"
            },
            new()
            {
                Email = "marta.kasztan@o2.pl",
                FirstName = "Marta",
                Surname = "Kasztan"
            }
        };

        var userRepositoryMock = new Moq.Mock<IUserRepository>();
        userRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(users);

        var sut = new UserService(userRepositoryMock.Object);
        var result = await sut.GetAllUsersBasicInfoAsync();

        result.Should().NotBeEmpty();
        result.Should().HaveCount(2);
        result.First().Email.Should().Be("grzegorz.bulka@wp.pl");
        result.Last().FirstName.Should().Be("Marta");

    }
}