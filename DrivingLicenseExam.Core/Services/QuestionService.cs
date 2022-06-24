using DrivingLicenseExam.Core.DTO;
using DrivingLicenseExam.Infrastructure.Entities;
using DrivingLicenseExam.Infrastructure.Repository;

namespace DrivingLicenseExam.Core.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionService(IQuestionRepository questionRepository, IAnswerRepository answerRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<IEnumerable<QuestionBasicInformationResponseDto>> GetAllQuestionsBasicInfoAsync()
    {
        var questions = await _questionRepository.GetAllAsync();
        List<AnswerBasicInformationResponseDto> answersList = new List<AnswerBasicInformationResponseDto>();
        
        foreach (var question in questions)
        {
            foreach (var answer in question.Answers)
            {
                answersList.Add(new AnswerBasicInformationResponseDto(
                    answer.Content,
                    answer.QuestionId,
                    answer.IsCorrect));
            }
        }
        
        return questions.Select(x => new QuestionBasicInformationResponseDto(
            x.Content,
            new ImageBasicRequestDto(x.Image.Data),
            answersList.FindAll(y=> y.QuestionId == x.Id)));
    }

    public async Task AddNewQuestionAsync(QuestionCreationRequestDto dto)
    {
        var questionAnswers = new List<Answer>();
        foreach (var answer in dto.Answers)
        {
            questionAnswers.Add(new Answer
            {
                Content = answer.Content,
                IsCorrect = answer.IsCorrect
            });
        }
        
        await _questionRepository.AddAsync(new Question
        {
            Content = dto.Content,
            Answers = questionAnswers,
            Image = new Image
            {
                Data = dto.Image.Data
            }
        });
    }

    public async Task UpdateExistingQuestionAsync(QuestionUpdateRequestDto dto)
    {
        var questionAnswers = new List<Answer>();
        foreach (var answer in dto.QuestionCreationRequestDto.Answers)
        {
            questionAnswers.Add(new Answer
            {
                Content = answer.Content,
                IsCorrect = answer.IsCorrect
            });
        }
        
        await _questionRepository.UpdateAsync(new Question
        {
            Content = dto.QuestionCreationRequestDto.Content,
            Answers = questionAnswers,
            Image = new Image
            {
                Data = dto.QuestionCreationRequestDto.Image.Data
            },
            Id = dto.ExistingQuestionId
        });
    }

    public async Task DeleteExistingQuestionByIdAsync(int id)
    {
        await _questionRepository.DeleteById(id);
    }
}