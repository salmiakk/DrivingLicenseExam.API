namespace DrivingLicenseExam.Core.Entities;

public abstract class Question : BaseEntity
{
    public string Content { get; set; }
    public Image Image { get; set; }
}