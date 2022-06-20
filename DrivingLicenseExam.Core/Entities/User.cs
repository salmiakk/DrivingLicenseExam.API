namespace DrivingLicenseExam.Core.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}