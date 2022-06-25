using DrivingLicenseExam.Infrastructure.Context;
using DrivingLicenseExam.Infrastructure.Entities;
using DrivingLicenseExam.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DrivingLicenseExam.Infrastructure.Repository;

public class QuestionRepository : IQuestionRepository
{
    private readonly MainContext _mainContext;
    private readonly ILogger<IQuestionRepository> _logger;

    public QuestionRepository(MainContext mainContext, ILogger<IQuestionRepository> logger)
    {
        _mainContext = mainContext;
        _logger = logger;
    }

    public async Task<IEnumerable<Question>> GetAllAsync()
    {
        var questions = await _mainContext.Question.ToListAsync();
        foreach (var question in questions)
        {
            await _mainContext.Entry(question).Reference(x => x.Image).LoadAsync();
            await _mainContext.Entry(question).Collection<Answer>(x => x.Answers).LoadAsync();
        }

        return questions;
    }

    public async Task<Question> GetByIdAsync(int id)
    {
        var question = await _mainContext.Question.SingleOrDefaultAsync(x => x.Id == id);

        if (question != null)
        {
            await _mainContext.Entry(question).Reference(x => x.Image).LoadAsync();
            await _mainContext.Entry(question).Collection<Answer>(x => x.Answers).LoadAsync();
            return question;
        }
        _logger.LogError("Cannot find question with provided id: {QuestionId}", id);
        throw new EntityNotFoundException();
    }

    public async Task AddAsync(Question entity)
    {
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Question entity)
    {
        var questionsToUpdate = await _mainContext.Question.SingleOrDefaultAsync(x => x.Id == entity.Id);
        
        if (questionsToUpdate == null)
        {
            _logger.LogError("Cannot find question with provided id: {QuestionId}", entity.Id);
            throw new EntityNotFoundException();
        }
        
        await _mainContext.Entry(questionsToUpdate).Reference(x => x.Image).LoadAsync();
        await _mainContext.Entry(questionsToUpdate).Collection(x => x.Answers).LoadAsync();
        
        questionsToUpdate.Answers = entity.Answers;
        questionsToUpdate.Content = entity.Content;
        questionsToUpdate.Image = entity.Image;
        questionsToUpdate.DateOfUpdate = DateTime.UtcNow;

        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var questionsToDelete = await _mainContext.Question.SingleOrDefaultAsync(x => x.Id == id);
        if (questionsToDelete != null)
        {
            _mainContext.Question.Remove(questionsToDelete);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            _logger.LogError("Cannot find question with provided id: {QuestionId}", id);
            throw new EntityNotFoundException();
        }


    }
}