namespace DrivingLicenseExam.Core.DTO;

public class AnswerCreationRequestDto
{
    public string Content { get; set; }
    
    public int QuestionId { get; set; }
    
    public bool IsCorrect { get; set; }

    public AnswerCreationRequestDto(string content, int questionId, bool isCorrect)
    {
        Content = content;
        QuestionId = questionId;
        IsCorrect = isCorrect;
    }
}