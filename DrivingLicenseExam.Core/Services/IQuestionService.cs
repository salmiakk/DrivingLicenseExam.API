using DrivingLicenseExam.Core.DTO;

namespace DrivingLicenseExam.Core.Services;

public interface IQuestionService
{    
    
    Task<IEnumerable<QuestionBasicInformationResponseDto>> GetAllQuestionsBasicInfoAsync();
    Task AddNewQuestionAsync(QuestionCreationRequestDto dto);
    Task UpdateExistingQuestionAsync(QuestionUpdateRequestDto dto);
    Task DeleteExistingQuestionByIdAsync(int id);

}