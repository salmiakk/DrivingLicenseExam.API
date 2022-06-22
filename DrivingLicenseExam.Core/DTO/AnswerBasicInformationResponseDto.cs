namespace DrivingLicenseExam.Core.DTO;

public class AnswerBasicInformationResponseDto
{
    public string Content { get; set; }
    
    public int QuestionId { get; set; }
    
    public bool IsCorrect { get; set; }

    public AnswerBasicInformationResponseDto(string content, int questionId, bool isCorrect)
    {
        Content = content;
        QuestionId = questionId;
        IsCorrect = isCorrect;
    }
}