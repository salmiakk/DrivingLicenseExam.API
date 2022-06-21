namespace DrivingLicenseExam.Infrastructure.Entities;

public class Answer : BaseEntity
{
    public string Content { get; set; }
    public Question Question { get; set; }
    public int QuestionId { get; set; }
    
    public bool IsCorrect { get; set; }

}