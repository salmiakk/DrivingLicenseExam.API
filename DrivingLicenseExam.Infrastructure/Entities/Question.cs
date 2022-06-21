namespace DrivingLicenseExam.Infrastructure.Entities;

public class Question : BaseEntity
{
    public string Content { get; set; }
    public Image Image { get; set; }
    
    public IEnumerable<Answer> Answers { get; set; }
    
}