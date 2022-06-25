using DrivingLicenseExam.Core.DTO;
using DrivingLicenseExam.Core.Services;
using DrivingLicenseExam.Infrastructure.Entities;
using DrivingLicenseExam.Infrastructure.Exceptions;
using DrivingLicenseExam.Infrastructure.Repository;
using FluentAssertions;
using Moq;

namespace DrivingLicenseExam.Tests;

public class QuestionServiceTests
{
    [Fact]
    public async Task GetAllQuestionsBasicInfoAsync_ShouldReturnEmpty_WhenQuestionsCollectionIsEmpty()
    {
        var sut = new QuestionService(Mock.Of<IQuestionRepository>());

        var result = await sut.GetAllQuestionsBasicInfoAsync();

        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllQuestionsBasicInfoAsync_ShouldReturnTwoElements_WhenQuestionsCollectionHasTwoElements()
    {
        var questions = new List<Question>
        {
            new()
            {
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        Content = "Tak",
                        IsCorrect = false
                    },
                    new Answer
                    {
                        Content = "Nie",
                        IsCorrect = true
                    }
                },
                Content = "Czy rowerzysta moze poruszac sie droga rowerowa?",
                Image = new Image()
            },
            new()
            {
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        Content = "50km/h",
                        IsCorrect = true
                    },
                    new Answer
                    {
                        Content = "60km/h",
                        IsCorrect = false
                    }
                },
                Content = "Jaka jest maksymalna dozwolona predkosc w obszarze zabudowanym?",
                Image = new Image()
            }
        };
        var questionRepositoryMock = new Moq.Mock<IQuestionRepository>();
        questionRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(questions);

        var sut = new QuestionService(questionRepositoryMock.Object);
        var result = await sut.GetAllQuestionsBasicInfoAsync();

        result.Should().NotBeEmpty();
        result.Should().HaveCount(2);
        result.First().Content.Should().Be("Czy rowerzysta moze poruszac sie droga rowerowa?");
        result.Last().Content.Should().Be("Jaka jest maksymalna dozwolona predkosc w obszarze zabudowanym?");
    }

    [Fact]
    public async Task DeleteExistingQuestionByIdAsync_ShouldInvokeRepositoryDeleteById_WhenGivenIntParameter()
    {
        var questionRepositoryMock = new Moq.Mock<IQuestionRepository>();

        questionRepositoryMock.Setup(x => x.DeleteById(It.IsAny<int>()));
        
        var sut = new QuestionService(questionRepositoryMock.Object);
        
        var result = sut.DeleteExistingQuestionByIdAsync(2);
        
        questionRepositoryMock.Verify(x=> x.DeleteById(2));

    }

    [Fact]
    public async Task AddNewQuestionAsync_ShouldInvokeRepositoryAdd_WhenGivenQuestionDtoParameter()
    {
        var questionRepositoryMock = new Moq.Mock<IQuestionRepository>();

        questionRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Question>()));
        
        var sut = new QuestionService(questionRepositoryMock.Object);
        
        var dto = new QuestionCreationRequestDto(answers: new List<AnswerCreationRequestDto>
        {
            new(content: "50km/h", isCorrect: true, questionId: 1),
            new(content: "60km/h", isCorrect: false, questionId: 1)
        },content: "Jaka jest maksymalna dozwolona predkosc w obszarze zabudowanym?" , image: new ImageBasicRequestDto(data: new byte[] { 0, 1, 0 }));
        
        var result = sut.AddNewQuestionAsync(dto);

        questionRepositoryMock.Verify(x=> x.AddAsync(It.IsAny<Question>()));
    }

}