using DrivingLicenseExam.Core.DTO;

namespace DrivingLicenseExam.Core.Services;

public interface IAnswerService
{
    Task<IEnumerable<AnswerBasicInformationResponseDto>> GetAllAnswersBasicInfoAsync();
    Task AddNewAnswerToExistingQuestionAsync(AnswerCreationRequestDto dto);
}