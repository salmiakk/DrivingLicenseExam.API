using DrivingLicenseExam.Core.DTO;
using DrivingLicenseExam.Infrastructure.Entities;
using DrivingLicenseExam.Infrastructure.Repository;

namespace DrivingLicenseExam.Core.Services;

public class AnswerService : IAnswerService
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IQuestionRepository _questionRepository;

    public AnswerService(IAnswerRepository answerRepository, IQuestionRepository questionRepository)
    {
        _answerRepository = answerRepository;
        _questionRepository = questionRepository;
    }
    
    public async Task<IEnumerable<AnswerBasicInformationResponseDto>> GetAllAnswersBasicInfoAsync()
    {
        var answers = await _answerRepository.GetAllAsync();
        return answers.Select(x => new AnswerBasicInformationResponseDto(
            x.Content,
            x.QuestionId,
            x.IsCorrect));
    }
}