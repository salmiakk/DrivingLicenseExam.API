namespace DrivingLicenseExam.Core.DTO;

public class UserBasicRequestDto
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    public UserBasicRequestDto(string firstName, string surname, string email)
    {
        FirstName = firstName;
        Surname = surname;
        Email = email;
    }
}