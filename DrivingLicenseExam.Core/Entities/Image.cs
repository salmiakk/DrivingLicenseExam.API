namespace DrivingLicenseExam.Core.Entities;

public class Image : BaseEntity
{
    public byte[] Data { get; set; }
    
    public int QuestionId { get; set; }
    public Question Question { get; set; }

}