using DrivingLicenseExam.Infrastructure.Entities;

namespace DrivingLicenseExam.Core.DTO;

public class QuestionCreationRequestDto
{
    public string Content { get; set; }
    public ImageBasicRequestDto Image { get; set; }
    public IEnumerable<AnswerCreationRequestDto> Answers { get; set; }

    public QuestionCreationRequestDto(string content, ImageBasicRequestDto image, IEnumerable<AnswerCreationRequestDto> answers)
    {
        Content = content;
        Image = image;
        Answers = answers;
    }

    public QuestionCreationRequestDto(IEnumerable<AnswerCreationRequestDto> answers, ImageBasicRequestDto image)
    {
        Answers = answers;
        Image = image;
    }
}