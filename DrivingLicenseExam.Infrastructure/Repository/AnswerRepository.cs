using System.Reflection.Metadata.Ecma335;
using DrivingLicenseExam.Infrastructure.Context;
using DrivingLicenseExam.Infrastructure.Entities;
using DrivingLicenseExam.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DrivingLicenseExam.Infrastructure.Repository;

public class AnswerRepository : IAnswerRepository
{
    public readonly MainContext _mainContext;

    public AnswerRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<IEnumerable<Answer>> GetAllAsync()
    {
        var answers = await _mainContext.Answer.ToListAsync();
        foreach (var answer in answers)
        {
            await _mainContext.Entry(answer).Reference(x => x.Question).LoadAsync();
        }

        return answers;
    }

    public async Task<Answer> GetByIdAsync(int id)
    {
        var answer = await _mainContext.Answer.SingleOrDefaultAsync(x => x.Id == id);
        if (answer != null)
        {
            await _mainContext.Entry(answer).Reference(x => x.Question).LoadAsync();
            return answer;
        }

        throw new EntityNotFoundException();
    }

    public async Task AddAsync(Answer entity)
    {
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Answer entity)
    {
        var answerToUpdate = await _mainContext.Answer.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (answerToUpdate == null)
        {
            throw new EntityNotFoundException();
        }

        answerToUpdate.Content = entity.Content;
        answerToUpdate.IsCorrect = entity.IsCorrect;
        answerToUpdate.Question = entity.Question;
        answerToUpdate.QuestionId = entity.QuestionId;
        answerToUpdate.DateOfUpdate = DateTime.UtcNow;

        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var answerToDelete = await _mainContext.Answer.SingleOrDefaultAsync(x => x.Id == id);
        if (answerToDelete != null)
        {
            _mainContext.Answer.Remove(answerToDelete);
            await _mainContext.SaveChangesAsync();
        }

        throw new EntityNotFoundException();
    }
}