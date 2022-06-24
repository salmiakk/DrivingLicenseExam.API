namespace DrivingLicenseExam.Core.DTO;

public class QuestionUpdateRequestDto
{
    public int ExistingQuestionId { get; set; }
    public QuestionCreationRequestDto QuestionCreationRequestDto { get; set; }

    public QuestionUpdateRequestDto(int existingQuestionId, QuestionCreationRequestDto questionCreationRequestDto)
    {
        ExistingQuestionId = existingQuestionId;
        QuestionCreationRequestDto = questionCreationRequestDto;
    }
}