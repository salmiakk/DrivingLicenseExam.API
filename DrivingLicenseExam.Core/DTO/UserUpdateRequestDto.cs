namespace DrivingLicenseExam.Core.DTO;

public class UserUpdateRequest
{
    public int ExistingUserId { get; set; }
    
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    public UserUpdateRequest(int existingUserId, string firstName, string surname, string email)
    {
        ExistingUserId = existingUserId;
        FirstName = firstName;
        Surname = surname;
        Email = email;
    }
}