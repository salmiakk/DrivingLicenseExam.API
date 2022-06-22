using DrivingLicenseExam.Core.DTO;
using DrivingLicenseExam.Infrastructure.Repository;

namespace DrivingLicenseExam.Core.Services;

public class AnswerService : IAnswerService
{
    private readonly IAnswerRepository _answerRepository;

    public AnswerService(IAnswerRepository answerRepository)
    {
        _answerRepository = answerRepository;
    }

    public Task<IEnumerable<AnswerBasicInformationResponseDto>> GetAllAnswersBasicInfoAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddNewAnswerToExistingQuestionAsync(AnswerCreationRequestDto dto)
    {
        throw new NotImplementedException();
    }
}