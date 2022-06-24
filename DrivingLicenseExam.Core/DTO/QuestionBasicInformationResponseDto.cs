using DrivingLicenseExam.Infrastructure.Entities;

namespace DrivingLicenseExam.Core.DTO;

public class QuestionBasicInformationResponseDto
{
    public string Content { get; set; }
    public ImageBasicRequestDto Image { get; set; }
    public IEnumerable<AnswerBasicInformationResponseDto> Answers { get; set; }

    public QuestionBasicInformationResponseDto(string content, ImageBasicRequestDto image, IEnumerable<AnswerBasicInformationResponseDto> answers)
    {
        Content = content;
        Image = image;
        Answers = answers;
    }
}