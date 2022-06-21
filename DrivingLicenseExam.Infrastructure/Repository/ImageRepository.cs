using DrivingLicenseExam.Infrastructure.Context;
using DrivingLicenseExam.Infrastructure.Entities;

namespace DrivingLicenseExam.Infrastructure.Repository;

public class ImageRepository : IImageRepository
{
    public readonly MainContext _mainContext;

    public ImageRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Image>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Image> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Add(Image entity)
    {
        throw new NotImplementedException();
    }

    public async Task Update(Image entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}