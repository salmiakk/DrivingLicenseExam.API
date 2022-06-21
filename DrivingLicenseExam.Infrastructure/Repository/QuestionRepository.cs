using DrivingLicenseExam.Infrastructure.Context;
using DrivingLicenseExam.Infrastructure.Entities;

namespace DrivingLicenseExam.Infrastructure.Repository;

public class QuestionRepository : IQuestionRepository
{
    public readonly MainContext _mainContext;

    public QuestionRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<IEnumerable<Question>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Question> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Add(Question entity)
    {
        throw new NotImplementedException();
    }

    public async Task Update(Question entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}